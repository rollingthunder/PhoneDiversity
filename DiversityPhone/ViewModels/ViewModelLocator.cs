﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Funq;
using DiversityPhone.Services;
using ReactiveUI;

namespace DiversityPhone.ViewModels
{
    public partial class ViewModelLocator
    {
        private const string OFFLINE_STORAGE = "OfflineStorage";
        private static Container _ioc;
        private static IMessageBus _messenger = MessageBus.Current;

        private static HomeViewModel _homeVM;
        private static EventSeriesViewModel _hierarchyVM;
        private static EditESVM _editESVM;

        public ViewModelLocator(Container services)
        {
            _ioc = services;
            #region ViewModel Factories
            _ioc.Register<HomeViewModel>(container => new HomeViewModel(container.Resolve<INavigationService>()));
            _ioc.Register<EventSeriesViewModel>(container => new EventSeriesViewModel(                
                container.Resolve<INavigationService>(),
                container.Resolve<IOfflineStorage>(),
                container.Resolve<IMessageBus>()
                ));
            _ioc.Register<EditESVM>(c => new EditESVM(c.Resolve<INavigationService>(), c.Resolve<IMessageBus>()));

            #endregion

            #region ViewModel Instantiation
            _homeVM = _ioc.Resolve<HomeViewModel>();            

            _hierarchyVM = _ioc.Resolve<EventSeriesViewModel>();            

            _editESVM = _ioc.Resolve<EditESVM>();
            #endregion

        }

        public HomeViewModel Home { get { return _homeVM; } }
        public EventSeriesViewModel EventSeries { get { return _hierarchyVM; } }
        public EditESVM EditES { get { return _editESVM; } }
           
    }
}
