﻿using System;
using System.Net;
using System.Reactive.Linq;
using ReactiveUI;
using System.Linq;
using DiversityPhone.Model;
using ReactiveUI.Xaml;
using DiversityPhone.Messages;
using System.Collections.Generic;
using DiversityPhone.Services;
using Funq;
using System.Reactive.Concurrency;
using System.Reactive.Subjects;

namespace DiversityPhone.ViewModels
{
    public class EditPropertyVM : EditPageVMBase<EventProperty>
    {        

        private ObservableAsyncMRUCache<int, IReactiveCollection<PropertyName>> _PropertyNamesCache;
        private ReactiveCollection<Property> _Properties;
        private BehaviorSubject<IEnumerable<int>> _UsedProperties;


        #region Services        
        private IVocabularyService Vocabulary { get; set; }
        private IFieldDataService Storage { get; set; }   
        #endregion        

        #region Properties    
   

        public bool IsNew { get { return _IsNew.Value; } }
        private ObservableAsPropertyHelper<bool> _IsNew;

        private Property NoProperty = new Property() { DisplayText = DiversityResources.Setup_Item_PleaseChoose };
        public ListSelectionHelper<Property> Properties { get; private set; }

        private PropertyName NoValue = new PropertyName() { DisplayText = DiversityResources.Setup_Item_PleaseChoose };
        public ListSelectionHelper<PropertyName> Values { get; private set; }
        #endregion      


        public EditPropertyVM(Container ioc)                  
        {
            Vocabulary = ioc.Resolve<IVocabularyService>();
            Storage = ioc.Resolve<IFieldDataService>();

            _UsedProperties = new BehaviorSubject<IEnumerable<int>>(Enumerable.Empty<int>());
            Messenger.Listen<IEnumerable<int>>(VMMessages.USED_EVENTPROPERTY_IDS)
                .Subscribe(_UsedProperties);

            _Properties = this.FirstActivation()
                .SelectMany(_ => 
                    Vocabulary.getAllProperties()
                    .ToObservable(Scheduler.ThreadPool)
                    )
                    .ObserveOnDispatcher()
                    .CreateCollection();

            _PropertyNamesCache = new ObservableAsyncMRUCache<int, IReactiveCollection<PropertyName>>(
                propertyID => 
                    Observable.Start(
                    () => Vocabulary
                    .getPropertyNames(propertyID)
                    .ToObservable(Scheduler.ThreadPool)
                    .ObserveOnDispatcher()
                    .CreateCollection() as IReactiveCollection<PropertyName>), 3);

            _IsNew = this.ObservableToProperty(CurrentModelObservable.Select(m => m.IsNew()), x => x.IsNew, false);
            
            
            Properties = new ListSelectionHelper<Property>();  
            CurrentModelObservable
                .Select(evprop => 
                    {
                        var isNew = evprop.IsNew();
                        var usedProps = _UsedProperties.First();

                        return
                        _Properties                                                                                 
                            .CreateDerivedCollection(p => p, p => 
                                p.PropertyID == evprop.PropertyID //Editing property -> can't change type
                                || (isNew && !usedProps.Contains(p.PropertyID)),//New Property, only show unused ones
                                (p1,p2) => p1.PropertyID.CompareTo(p2.PropertyID)
                                );                            
                    })      
                //Select first property automatically after adding it
                .Do(props => props
                    .ItemsAdded
                    .Where(item => item != NoProperty)
                    .Take(1)
                    .Subscribe(item => Properties.SelectedItem = item)
                    )
                .Select(coll => coll as IList<Property>)
                .Subscribe(Properties);

            Values = new ListSelectionHelper<PropertyName>();
            Properties                  
                .SelectMany(prop => 
                    {
                        return
                            (prop == null || prop == NoProperty)
                            ? Observable.Return(new ReactiveCollection<PropertyName>(Enumerable.Repeat(NoValue, 1)) as IReactiveCollection<PropertyName>)
                            : _PropertyNamesCache.AsyncGet(prop.PropertyID);
                    })
                    //Reselect value that was selected
                    .Do(values => 
                        values
                        .ItemsAdded
                        .Where(item => item.PropertyUri == Current.Model.PropertyUri)
                        .Subscribe(value => Values.SelectedItem = value)
                        )
                    .Select(coll => coll as IList<PropertyName>)
                    .ObserveOnDispatcher()
                .Subscribe(Values);
          

            CanSaveObs()
                .Subscribe(CanSaveSubject.OnNext);
        }

       
        private IObservable<bool> CanSaveObs()
        {            
            var propSelected = Properties
                .Select(x => x!=NoProperty)
                .StartWith(false);

            var valueSelected = Values
                 .Select(x => x != NoValue)
                 .StartWith(false);

            return Extensions.BooleanAnd(propSelected, valueSelected);
        }         


        protected override void UpdateModel()
        {           
            Current.Model.PropertyID = Properties.SelectedItem.PropertyID;
            Current.Model.PropertyUri = Values.SelectedItem.PropertyUri;
            Current.Model.DisplayText = Values.SelectedItem.DisplayText;
        }
    }
}
