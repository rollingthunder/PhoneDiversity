﻿using DiversityPhone.Interface;
using Microsoft.Reactive.Testing;
using Moq;
using Ninject;
using Ninject.MockingKernel;
using Ninject.MockingKernel.Moq;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;

namespace DiversityPhone.Test
{
    public class SingleUseEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _Inner;
        private bool enumerated;

        public SingleUseEnumerable(IEnumerable<T> inner)
        {
            _Inner = inner;
            enumerated = false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (enumerated)
            {
                foreach (var item in Enumerable.Empty<T>())
                    yield return item;
            }
            else
            {
                enumerated = true;
                foreach (var item in _Inner)
                {
                    yield return item;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class TestServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRefreshVocabularyTask>().ToMock();
            Bind<IScheduler>().ToConstant(ImmediateScheduler.Instance);
        }
    }

    public class UnitTestKernel : MoqMockingKernel
    {
        public UnitTestKernel()
        {
        }
    }

    public class DiversityTestBase<TTest> : ReactiveTest
    {
        protected readonly UnitTestKernel K;
        protected readonly TestScheduler Scheduler;
        private TTest _T;
        private bool _GotT = false;

        protected TTest T
        {
            get
            {
                if (_GotT)
                    return _T;
                else
                    return (_T = K.Get<TTest>());
            }
        }

        protected readonly Mock<IDiversityServiceClient> Service;
        protected readonly Mock<IConnectivityService> Connectivity;
        protected readonly Mock<INotificationService> Notifications;
        protected readonly Mock<IKeyMappingService> Mappings;
        protected readonly Mock<IFieldDataService> Storage;
        protected readonly Mock<IVocabularyService> Vocabulary;
        protected readonly Mock<ITaxonService> Taxa;
        protected readonly Mock<ISettingsService> Settings;

        protected IObservable<T> Return<T>(T value)
        {
            return Observable.Return(value, Scheduler);
        }

        protected IObservable<T> ReturnAndNever<T>(T value)
        {
            return Observable.Return(value, Scheduler).Concat(Observable.Never<T>());
        }

        protected Mock<Q> RecursiveMock<Q>() where Q : class
        {
            var s = K.GetMock<Q>();
            s.DefaultValue = DefaultValue.Mock;
            return s;
        }

        protected Mock<Q> Mock<Q>() where Q : class
        {
            return K.GetMock<Q>();
        }

        protected void GetT()
        {
            var x = T;
        }

        public DiversityTestBase()
        {
            K = new UnitTestKernel();
            K.Load<TestServiceModule>();

            Scheduler = new TestScheduler();

            Service = K.GetMock<IDiversityServiceClient>();
            Service.DefaultValue = DefaultValue.Mock;

            Connectivity = K.GetMock<IConnectivityService>();
            Notifications = K.GetMock<INotificationService>();
            Mappings = K.GetMock<IKeyMappingService>();
            Storage = K.GetMock<IFieldDataService>();
            Vocabulary = K.GetMock<IVocabularyService>();
            Taxa = K.GetMock<ITaxonService>();
            Settings = K.GetMock<ISettingsService>();
        }
    }
}