﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.235
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestClient.DiversityService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CollectionEvent", Namespace="http://schemas.datacontract.org/2004/07/ConsoleApplication1")]
    [System.SerializableAttribute()]
    public partial class CollectionEvent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CollectingMethodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> CollectionDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CollectionDateCategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CollectionDateSupplementField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> CollectionDayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CollectionEventIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<byte> CollectionMonthField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CollectionTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CollectionTimeSpanField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> CollectionYearField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CollectorsEventNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CountryCacheField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DataWithholdingReasonField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HabitatDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocalityDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LogCreatedByField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> LogCreatedWhenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LogUpdatedByField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> LogUpdatedWhenField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NotesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReferenceDetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReferenceTitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReferenceURIField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid RowGUIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> SeriesIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int VersionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> xx_ExpeditionIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool xx_IsAvailableField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CollectingMethod {
            get {
                return this.CollectingMethodField;
            }
            set {
                if ((object.ReferenceEquals(this.CollectingMethodField, value) != true)) {
                    this.CollectingMethodField = value;
                    this.RaisePropertyChanged("CollectingMethod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> CollectionDate {
            get {
                return this.CollectionDateField;
            }
            set {
                if ((this.CollectionDateField.Equals(value) != true)) {
                    this.CollectionDateField = value;
                    this.RaisePropertyChanged("CollectionDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CollectionDateCategory {
            get {
                return this.CollectionDateCategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CollectionDateCategoryField, value) != true)) {
                    this.CollectionDateCategoryField = value;
                    this.RaisePropertyChanged("CollectionDateCategory");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CollectionDateSupplement {
            get {
                return this.CollectionDateSupplementField;
            }
            set {
                if ((object.ReferenceEquals(this.CollectionDateSupplementField, value) != true)) {
                    this.CollectionDateSupplementField = value;
                    this.RaisePropertyChanged("CollectionDateSupplement");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> CollectionDay {
            get {
                return this.CollectionDayField;
            }
            set {
                if ((this.CollectionDayField.Equals(value) != true)) {
                    this.CollectionDayField = value;
                    this.RaisePropertyChanged("CollectionDay");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CollectionEventID {
            get {
                return this.CollectionEventIDField;
            }
            set {
                if ((this.CollectionEventIDField.Equals(value) != true)) {
                    this.CollectionEventIDField = value;
                    this.RaisePropertyChanged("CollectionEventID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> CollectionMonth {
            get {
                return this.CollectionMonthField;
            }
            set {
                if ((this.CollectionMonthField.Equals(value) != true)) {
                    this.CollectionMonthField = value;
                    this.RaisePropertyChanged("CollectionMonth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CollectionTime {
            get {
                return this.CollectionTimeField;
            }
            set {
                if ((object.ReferenceEquals(this.CollectionTimeField, value) != true)) {
                    this.CollectionTimeField = value;
                    this.RaisePropertyChanged("CollectionTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CollectionTimeSpan {
            get {
                return this.CollectionTimeSpanField;
            }
            set {
                if ((object.ReferenceEquals(this.CollectionTimeSpanField, value) != true)) {
                    this.CollectionTimeSpanField = value;
                    this.RaisePropertyChanged("CollectionTimeSpan");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> CollectionYear {
            get {
                return this.CollectionYearField;
            }
            set {
                if ((this.CollectionYearField.Equals(value) != true)) {
                    this.CollectionYearField = value;
                    this.RaisePropertyChanged("CollectionYear");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CollectorsEventNumber {
            get {
                return this.CollectorsEventNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.CollectorsEventNumberField, value) != true)) {
                    this.CollectorsEventNumberField = value;
                    this.RaisePropertyChanged("CollectorsEventNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CountryCache {
            get {
                return this.CountryCacheField;
            }
            set {
                if ((object.ReferenceEquals(this.CountryCacheField, value) != true)) {
                    this.CountryCacheField = value;
                    this.RaisePropertyChanged("CountryCache");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DataWithholdingReason {
            get {
                return this.DataWithholdingReasonField;
            }
            set {
                if ((object.ReferenceEquals(this.DataWithholdingReasonField, value) != true)) {
                    this.DataWithholdingReasonField = value;
                    this.RaisePropertyChanged("DataWithholdingReason");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HabitatDescription {
            get {
                return this.HabitatDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.HabitatDescriptionField, value) != true)) {
                    this.HabitatDescriptionField = value;
                    this.RaisePropertyChanged("HabitatDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LocalityDescription {
            get {
                return this.LocalityDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.LocalityDescriptionField, value) != true)) {
                    this.LocalityDescriptionField = value;
                    this.RaisePropertyChanged("LocalityDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LogCreatedBy {
            get {
                return this.LogCreatedByField;
            }
            set {
                if ((object.ReferenceEquals(this.LogCreatedByField, value) != true)) {
                    this.LogCreatedByField = value;
                    this.RaisePropertyChanged("LogCreatedBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> LogCreatedWhen {
            get {
                return this.LogCreatedWhenField;
            }
            set {
                if ((this.LogCreatedWhenField.Equals(value) != true)) {
                    this.LogCreatedWhenField = value;
                    this.RaisePropertyChanged("LogCreatedWhen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LogUpdatedBy {
            get {
                return this.LogUpdatedByField;
            }
            set {
                if ((object.ReferenceEquals(this.LogUpdatedByField, value) != true)) {
                    this.LogUpdatedByField = value;
                    this.RaisePropertyChanged("LogUpdatedBy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> LogUpdatedWhen {
            get {
                return this.LogUpdatedWhenField;
            }
            set {
                if ((this.LogUpdatedWhenField.Equals(value) != true)) {
                    this.LogUpdatedWhenField = value;
                    this.RaisePropertyChanged("LogUpdatedWhen");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Notes {
            get {
                return this.NotesField;
            }
            set {
                if ((object.ReferenceEquals(this.NotesField, value) != true)) {
                    this.NotesField = value;
                    this.RaisePropertyChanged("Notes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReferenceDetails {
            get {
                return this.ReferenceDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.ReferenceDetailsField, value) != true)) {
                    this.ReferenceDetailsField = value;
                    this.RaisePropertyChanged("ReferenceDetails");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReferenceTitle {
            get {
                return this.ReferenceTitleField;
            }
            set {
                if ((object.ReferenceEquals(this.ReferenceTitleField, value) != true)) {
                    this.ReferenceTitleField = value;
                    this.RaisePropertyChanged("ReferenceTitle");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReferenceURI {
            get {
                return this.ReferenceURIField;
            }
            set {
                if ((object.ReferenceEquals(this.ReferenceURIField, value) != true)) {
                    this.ReferenceURIField = value;
                    this.RaisePropertyChanged("ReferenceURI");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid RowGUID {
            get {
                return this.RowGUIDField;
            }
            set {
                if ((this.RowGUIDField.Equals(value) != true)) {
                    this.RowGUIDField = value;
                    this.RaisePropertyChanged("RowGUID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> SeriesID {
            get {
                return this.SeriesIDField;
            }
            set {
                if ((this.SeriesIDField.Equals(value) != true)) {
                    this.SeriesIDField = value;
                    this.RaisePropertyChanged("SeriesID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Version {
            get {
                return this.VersionField;
            }
            set {
                if ((this.VersionField.Equals(value) != true)) {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> xx_ExpeditionID {
            get {
                return this.xx_ExpeditionIDField;
            }
            set {
                if ((this.xx_ExpeditionIDField.Equals(value) != true)) {
                    this.xx_ExpeditionIDField = value;
                    this.RaisePropertyChanged("xx_ExpeditionID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool xx_IsAvailable {
            get {
                return this.xx_IsAvailableField;
            }
            set {
                if ((this.xx_IsAvailableField.Equals(value) != true)) {
                    this.xx_IsAvailableField = value;
                    this.RaisePropertyChanged("xx_IsAvailable");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DiversityService.IDiversityService")]
    public interface IDiversityService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiversityService/GetEvents", ReplyAction="http://tempuri.org/IDiversityService/GetEventsResponse")]
        TestClient.DiversityService.CollectionEvent[] GetEvents(int skip, int count);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiversityService/AddEvent", ReplyAction="http://tempuri.org/IDiversityService/AddEventResponse")]
        void AddEvent(TestClient.DiversityService.CollectionEvent ev);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDiversityServiceChannel : TestClient.DiversityService.IDiversityService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DiversityServiceClient : System.ServiceModel.ClientBase<TestClient.DiversityService.IDiversityService>, TestClient.DiversityService.IDiversityService {
        
        public DiversityServiceClient() {
        }
        
        public DiversityServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DiversityServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiversityServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiversityServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestClient.DiversityService.CollectionEvent[] GetEvents(int skip, int count) {
            return base.Channel.GetEvents(skip, count);
        }
        
        public void AddEvent(TestClient.DiversityService.CollectionEvent ev) {
            base.Channel.AddEvent(ev);
        }
    }
}
