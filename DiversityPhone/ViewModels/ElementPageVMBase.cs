﻿using DiversityPhone.Services;
using ReactiveUI;
using System.Reactive.Linq;
using DiversityPhone.Messages;
using ReactiveUI.Xaml;
using System;

namespace DiversityPhone.ViewModels
{
    public abstract class ElementPageVMBase<T> : PageVMBase
    {
        private IElementVM<T> _Current;
        /// <summary>
        /// Provides Access to the most recent Model Object
        /// </summary>
        public IElementVM<T> Current
        {
            get { return _Current; }
            set { this.RaiseAndSetIfChanged(x => x.Current, ref _Current, value); } //Public for Binding
        }

        /// <summary>
        /// Provides the viewmodel retrieved from the PageState 
        /// if it is valid (i.e. non-null)
        /// </summary>
        protected IObservable<IElementVM<T>> CurrentObservable { get; private set; }


        protected IObservable<T> CurrentModelObservable { get; private set; }

        public ElementPageVMBase ()
	    {    
            var currentObs =
            this.ObservableForProperty(x => x.Current)
                .Value()
                .Publish();                
            CurrentObservable = currentObs;
            currentObs.Connect();

            var modelObs =
                CurrentObservable
                .SelectMany(vm => vm.ObservableForProperty(x => x.Model))
                .Value()
                .Merge(CurrentObservable.Select(vm => vm.Model))
                .Publish();
            CurrentModelObservable = modelObs;
            modelObs.Connect();


            //If the current element has been deleted in the meantime, navigate back.
            Observable.CombineLatest(
                ActivationObservable.Where(activated => activated).Select(_ => Current),
                Messenger.Listen<IElementVM<T>>(MessageContracts.DELETE),
                (current, deleted) => current == deleted
            )
                .Where(current_deleted => current_deleted)
                .Select(_ => Page.Previous)
                .ToMessage(); 
        }
    }
}
