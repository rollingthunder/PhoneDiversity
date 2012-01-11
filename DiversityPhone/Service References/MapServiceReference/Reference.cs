﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace DiversityPhone.MapServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/WcfMapService")]
    public partial class CompositeType : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool BoolValueField;
        
        private string StringValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MapServiceReference.IMapService")]
    public interface IMapService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/GetMapList", ReplyAction="http://tempuri.org/IMapService/GetMapListResponse")]
        System.IAsyncResult BeginGetMapList(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<string> EndGetMapList(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/GetMapUrl", ReplyAction="http://tempuri.org/IMapService/GetMapUrlResponse")]
        System.IAsyncResult BeginGetMapUrl(string mapID, System.AsyncCallback callback, object asyncState);
        
        string EndGetMapUrl(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/GetXmlUrl", ReplyAction="http://tempuri.org/IMapService/GetXmlUrlResponse")]
        System.IAsyncResult BeginGetXmlUrl(string mapID, System.AsyncCallback callback, object asyncState);
        
        string EndGetXmlUrl(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IMapService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IMapService/GetDataUsingDataContractResponse")]
        System.IAsyncResult BeginGetDataUsingDataContract(DiversityPhone.MapServiceReference.CompositeType composite, System.AsyncCallback callback, object asyncState);
        
        DiversityPhone.MapServiceReference.CompositeType EndGetDataUsingDataContract(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMapServiceChannel : DiversityPhone.MapServiceReference.IMapService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetMapListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetMapListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<string> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<string>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetMapUrlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetMapUrlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetXmlUrlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetXmlUrlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetDataUsingDataContractCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetDataUsingDataContractCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public DiversityPhone.MapServiceReference.CompositeType Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((DiversityPhone.MapServiceReference.CompositeType)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MapServiceClient : System.ServiceModel.ClientBase<DiversityPhone.MapServiceReference.IMapService>, DiversityPhone.MapServiceReference.IMapService {
        
        private BeginOperationDelegate onBeginGetMapListDelegate;
        
        private EndOperationDelegate onEndGetMapListDelegate;
        
        private System.Threading.SendOrPostCallback onGetMapListCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetMapUrlDelegate;
        
        private EndOperationDelegate onEndGetMapUrlDelegate;
        
        private System.Threading.SendOrPostCallback onGetMapUrlCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetXmlUrlDelegate;
        
        private EndOperationDelegate onEndGetXmlUrlDelegate;
        
        private System.Threading.SendOrPostCallback onGetXmlUrlCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetDataUsingDataContractDelegate;
        
        private EndOperationDelegate onEndGetDataUsingDataContractDelegate;
        
        private System.Threading.SendOrPostCallback onGetDataUsingDataContractCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public MapServiceClient() {
        }
        
        public MapServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MapServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MapServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MapServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<GetMapListCompletedEventArgs> GetMapListCompleted;
        
        public event System.EventHandler<GetMapUrlCompletedEventArgs> GetMapUrlCompleted;
        
        public event System.EventHandler<GetXmlUrlCompletedEventArgs> GetXmlUrlCompleted;
        
        public event System.EventHandler<GetDataUsingDataContractCompletedEventArgs> GetDataUsingDataContractCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DiversityPhone.MapServiceReference.IMapService.BeginGetMapList(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetMapList(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<string> DiversityPhone.MapServiceReference.IMapService.EndGetMapList(System.IAsyncResult result) {
            return base.Channel.EndGetMapList(result);
        }
        
        private System.IAsyncResult OnBeginGetMapList(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((DiversityPhone.MapServiceReference.IMapService)(this)).BeginGetMapList(callback, asyncState);
        }
        
        private object[] OnEndGetMapList(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<string> retVal = ((DiversityPhone.MapServiceReference.IMapService)(this)).EndGetMapList(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetMapListCompleted(object state) {
            if ((this.GetMapListCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetMapListCompleted(this, new GetMapListCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetMapListAsync() {
            this.GetMapListAsync(null);
        }
        
        public void GetMapListAsync(object userState) {
            if ((this.onBeginGetMapListDelegate == null)) {
                this.onBeginGetMapListDelegate = new BeginOperationDelegate(this.OnBeginGetMapList);
            }
            if ((this.onEndGetMapListDelegate == null)) {
                this.onEndGetMapListDelegate = new EndOperationDelegate(this.OnEndGetMapList);
            }
            if ((this.onGetMapListCompletedDelegate == null)) {
                this.onGetMapListCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetMapListCompleted);
            }
            base.InvokeAsync(this.onBeginGetMapListDelegate, null, this.onEndGetMapListDelegate, this.onGetMapListCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DiversityPhone.MapServiceReference.IMapService.BeginGetMapUrl(string mapID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetMapUrl(mapID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string DiversityPhone.MapServiceReference.IMapService.EndGetMapUrl(System.IAsyncResult result) {
            return base.Channel.EndGetMapUrl(result);
        }
        
        private System.IAsyncResult OnBeginGetMapUrl(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string mapID = ((string)(inValues[0]));
            return ((DiversityPhone.MapServiceReference.IMapService)(this)).BeginGetMapUrl(mapID, callback, asyncState);
        }
        
        private object[] OnEndGetMapUrl(System.IAsyncResult result) {
            string retVal = ((DiversityPhone.MapServiceReference.IMapService)(this)).EndGetMapUrl(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetMapUrlCompleted(object state) {
            if ((this.GetMapUrlCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetMapUrlCompleted(this, new GetMapUrlCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetMapUrlAsync(string mapID) {
            this.GetMapUrlAsync(mapID, null);
        }
        
        public void GetMapUrlAsync(string mapID, object userState) {
            if ((this.onBeginGetMapUrlDelegate == null)) {
                this.onBeginGetMapUrlDelegate = new BeginOperationDelegate(this.OnBeginGetMapUrl);
            }
            if ((this.onEndGetMapUrlDelegate == null)) {
                this.onEndGetMapUrlDelegate = new EndOperationDelegate(this.OnEndGetMapUrl);
            }
            if ((this.onGetMapUrlCompletedDelegate == null)) {
                this.onGetMapUrlCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetMapUrlCompleted);
            }
            base.InvokeAsync(this.onBeginGetMapUrlDelegate, new object[] {
                        mapID}, this.onEndGetMapUrlDelegate, this.onGetMapUrlCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DiversityPhone.MapServiceReference.IMapService.BeginGetXmlUrl(string mapID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetXmlUrl(mapID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        string DiversityPhone.MapServiceReference.IMapService.EndGetXmlUrl(System.IAsyncResult result) {
            return base.Channel.EndGetXmlUrl(result);
        }
        
        private System.IAsyncResult OnBeginGetXmlUrl(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string mapID = ((string)(inValues[0]));
            return ((DiversityPhone.MapServiceReference.IMapService)(this)).BeginGetXmlUrl(mapID, callback, asyncState);
        }
        
        private object[] OnEndGetXmlUrl(System.IAsyncResult result) {
            string retVal = ((DiversityPhone.MapServiceReference.IMapService)(this)).EndGetXmlUrl(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetXmlUrlCompleted(object state) {
            if ((this.GetXmlUrlCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetXmlUrlCompleted(this, new GetXmlUrlCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetXmlUrlAsync(string mapID) {
            this.GetXmlUrlAsync(mapID, null);
        }
        
        public void GetXmlUrlAsync(string mapID, object userState) {
            if ((this.onBeginGetXmlUrlDelegate == null)) {
                this.onBeginGetXmlUrlDelegate = new BeginOperationDelegate(this.OnBeginGetXmlUrl);
            }
            if ((this.onEndGetXmlUrlDelegate == null)) {
                this.onEndGetXmlUrlDelegate = new EndOperationDelegate(this.OnEndGetXmlUrl);
            }
            if ((this.onGetXmlUrlCompletedDelegate == null)) {
                this.onGetXmlUrlCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetXmlUrlCompleted);
            }
            base.InvokeAsync(this.onBeginGetXmlUrlDelegate, new object[] {
                        mapID}, this.onEndGetXmlUrlDelegate, this.onGetXmlUrlCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult DiversityPhone.MapServiceReference.IMapService.BeginGetDataUsingDataContract(DiversityPhone.MapServiceReference.CompositeType composite, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetDataUsingDataContract(composite, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        DiversityPhone.MapServiceReference.CompositeType DiversityPhone.MapServiceReference.IMapService.EndGetDataUsingDataContract(System.IAsyncResult result) {
            return base.Channel.EndGetDataUsingDataContract(result);
        }
        
        private System.IAsyncResult OnBeginGetDataUsingDataContract(object[] inValues, System.AsyncCallback callback, object asyncState) {
            DiversityPhone.MapServiceReference.CompositeType composite = ((DiversityPhone.MapServiceReference.CompositeType)(inValues[0]));
            return ((DiversityPhone.MapServiceReference.IMapService)(this)).BeginGetDataUsingDataContract(composite, callback, asyncState);
        }
        
        private object[] OnEndGetDataUsingDataContract(System.IAsyncResult result) {
            DiversityPhone.MapServiceReference.CompositeType retVal = ((DiversityPhone.MapServiceReference.IMapService)(this)).EndGetDataUsingDataContract(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetDataUsingDataContractCompleted(object state) {
            if ((this.GetDataUsingDataContractCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetDataUsingDataContractCompleted(this, new GetDataUsingDataContractCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetDataUsingDataContractAsync(DiversityPhone.MapServiceReference.CompositeType composite) {
            this.GetDataUsingDataContractAsync(composite, null);
        }
        
        public void GetDataUsingDataContractAsync(DiversityPhone.MapServiceReference.CompositeType composite, object userState) {
            if ((this.onBeginGetDataUsingDataContractDelegate == null)) {
                this.onBeginGetDataUsingDataContractDelegate = new BeginOperationDelegate(this.OnBeginGetDataUsingDataContract);
            }
            if ((this.onEndGetDataUsingDataContractDelegate == null)) {
                this.onEndGetDataUsingDataContractDelegate = new EndOperationDelegate(this.OnEndGetDataUsingDataContract);
            }
            if ((this.onGetDataUsingDataContractCompletedDelegate == null)) {
                this.onGetDataUsingDataContractCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetDataUsingDataContractCompleted);
            }
            base.InvokeAsync(this.onBeginGetDataUsingDataContractDelegate, new object[] {
                        composite}, this.onEndGetDataUsingDataContractDelegate, this.onGetDataUsingDataContractCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override DiversityPhone.MapServiceReference.IMapService CreateChannel() {
            return new MapServiceClientChannel(this);
        }
        
        private class MapServiceClientChannel : ChannelBase<DiversityPhone.MapServiceReference.IMapService>, DiversityPhone.MapServiceReference.IMapService {
            
            public MapServiceClientChannel(System.ServiceModel.ClientBase<DiversityPhone.MapServiceReference.IMapService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetMapList(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("GetMapList", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<string> EndGetMapList(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<string> _result = ((System.Collections.ObjectModel.ObservableCollection<string>)(base.EndInvoke("GetMapList", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetMapUrl(string mapID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = mapID;
                System.IAsyncResult _result = base.BeginInvoke("GetMapUrl", _args, callback, asyncState);
                return _result;
            }
            
            public string EndGetMapUrl(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("GetMapUrl", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetXmlUrl(string mapID, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = mapID;
                System.IAsyncResult _result = base.BeginInvoke("GetXmlUrl", _args, callback, asyncState);
                return _result;
            }
            
            public string EndGetXmlUrl(System.IAsyncResult result) {
                object[] _args = new object[0];
                string _result = ((string)(base.EndInvoke("GetXmlUrl", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetDataUsingDataContract(DiversityPhone.MapServiceReference.CompositeType composite, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = composite;
                System.IAsyncResult _result = base.BeginInvoke("GetDataUsingDataContract", _args, callback, asyncState);
                return _result;
            }
            
            public DiversityPhone.MapServiceReference.CompositeType EndGetDataUsingDataContract(System.IAsyncResult result) {
                object[] _args = new object[0];
                DiversityPhone.MapServiceReference.CompositeType _result = ((DiversityPhone.MapServiceReference.CompositeType)(base.EndInvoke("GetDataUsingDataContract", _args, result)));
                return _result;
            }
        }
    }
}