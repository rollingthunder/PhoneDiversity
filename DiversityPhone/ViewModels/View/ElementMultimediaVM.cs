﻿using System;
using ReactiveUI;
using DiversityPhone.Model;
using ReactiveUI.Xaml;
using DiversityPhone.Services;
using System.Linq;
using System.Reactive.Linq;
using DiversityPhone.Messages;
using System.Reactive.Subjects;

namespace DiversityPhone.ViewModels
{
    public class ElementMultimediaVM : ReactiveCollection<MultimediaObjectVM>, IObserver<IMultimediaOwner>
    {        
        IFieldDataService Storage;
        private ISubject<IMultimediaOwner> ownerSubject = new ReplaySubject<IMultimediaOwner>(1);
        private ReactiveAsyncCommand getMultimedia;

        public ReactiveCommand<IElementVM<MultimediaObjectVM>> SelectMultimedia { get; private set; }
        public ReactiveCommand AddMultimedia { get; private set; }
        public IObservable<IMultimediaOwner> NewMultimediaObservable { get; private set; }

        public ElementMultimediaVM(IFieldDataService storage)
        {            
            Storage = storage;

            getMultimedia = new ReactiveAsyncCommand();
            getMultimedia.RegisterAsyncFunction(own =>
                {
                    var owner = own as IMultimediaOwner;
                    return storage.getMultimediaForObject(owner.OwnerType, owner.OwnerID)
                        .Select(mmo => new MultimediaObjectVM(mmo))
                        .ToList();
                }).SelectMany(vms => vms)
                .Subscribe(this.Add);
            ownerSubject
                .Where(owner => getMultimedia.CanExecute(owner))                
                .Do(_ => this.Clear())
                .Subscribe(getMultimedia.Execute);

            SelectMultimedia = new ReactiveCommand<IElementVM<MultimediaObjectVM>>();
            SelectMultimedia
                .ToMessage(MessageContracts.EDIT);

            AddMultimedia = new ReactiveCommand();
            var newmmo =
            AddMultimedia
                .Select(_ => ownerSubject.FirstOrDefault())
                .Publish();
            NewMultimediaObservable = newmmo;
            newmmo.Connect();

        }

        public void OnCompleted()
        {
            ownerSubject.OnCompleted();
        }

        public void OnError(Exception exception)
        {
            ownerSubject.OnError(exception);   
        }

        public void OnNext(IMultimediaOwner value)
        {
            ownerSubject.OnNext(value);
        }
    }
}