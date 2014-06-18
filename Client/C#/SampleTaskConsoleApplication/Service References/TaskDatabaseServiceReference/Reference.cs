﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleTaskConsoleApplication.TaskDatabaseServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://sync.today/", ConfigurationName="TaskDatabaseServiceReference.TaskDatabaseSoap")]
    public interface TaskDatabaseSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account GetAccount(System.Guid accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccount", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account> GetAccountAsync(System.Guid accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccount2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account GetAccount2(string accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccount2", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account> GetAccount2Async(string accountId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTasks", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[] GetTasks(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTasks", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[]> GetTasksAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTasks2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[] GetTasks2(string accountId, string userInternalId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTasks2", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[]> GetTasks2Async(string accountId, string userInternalId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTask", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask GetTask(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTask", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> GetTaskAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTask2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask GetTask2(string accountId, string userInternalId, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetTask2", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> GetTask2Async(string accountId, string userInternalId, string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/SaveTask", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask SaveTask(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/SaveTask", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> SaveTaskAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/ChangeTaskExternalId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask ChangeTaskExternalId(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string oldId, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/ChangeTaskExternalId", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> ChangeTaskExternalIdAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string oldId, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetUserSalt", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        string GetUserSalt(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetUserSalt", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetUserSaltAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/LoginUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        bool LoginUser(SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/LoginUser", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> LoginUserAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/LoginUser2", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.User LoginUser2(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/LoginUser2", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.User> LoginUser2Async(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccountForClient", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(NuObject))]
        SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account GetAccountForClient(System.Guid userid, System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://sync.today/GetAccountForClient", ReplyAction="*")]
        System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account> GetAccountForClientAsync(System.Guid userid, System.Guid clientId);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class Account : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid internalIdField;
        
        private System.Guid belongsToUserField;
        
        private string usernameField;
        
        private string passwordField;
        
        private string serverField;
        
        private CommunicatorConnectInfo connectInfoField;
        
        private string accountAssemblyNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Guid InternalId {
            get {
                return this.internalIdField;
            }
            set {
                this.internalIdField = value;
                this.RaisePropertyChanged("InternalId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.Guid BelongsToUser {
            get {
                return this.belongsToUserField;
            }
            set {
                this.belongsToUserField = value;
                this.RaisePropertyChanged("BelongsToUser");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Server {
            get {
                return this.serverField;
            }
            set {
                this.serverField = value;
                this.RaisePropertyChanged("Server");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public CommunicatorConnectInfo ConnectInfo {
            get {
                return this.connectInfoField;
            }
            set {
                this.connectInfoField = value;
                this.RaisePropertyChanged("ConnectInfo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string AccountAssemblyName {
            get {
                return this.accountAssemblyNameField;
            }
            set {
                this.accountAssemblyNameField = value;
                this.RaisePropertyChanged("AccountAssemblyName");
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(SimpleCommunicatorConnectInfo))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class CommunicatorConnectInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuTask))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuRequirement))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public abstract partial class NuObject : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string externalIdField;
        
        private System.DateTime lastModifiedField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ExternalId {
            get {
                return this.externalIdField;
            }
            set {
                this.externalIdField = value;
                this.RaisePropertyChanged("ExternalId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime LastModified {
            get {
                return this.lastModifiedField;
            }
            set {
                this.lastModifiedField = value;
                this.RaisePropertyChanged("LastModified");
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NuRequirement))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class NuTask : NuObject {
        
        private string subjectField;
        
        private string bodyField;
        
        private System.Nullable<System.DateTime> startDateField;
        
        private System.Nullable<System.DateTime> dueDateField;
        
        private System.Nullable<System.DateTime> reminderField;
        
        private NuTaskPriority priorityField;
        
        private bool isPrivateField;
        
        private string companyField;
        
        private bool completedField;
        
        private NuRequirement[] parentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Subject {
            get {
                return this.subjectField;
            }
            set {
                this.subjectField = value;
                this.RaisePropertyChanged("Subject");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Body {
            get {
                return this.bodyField;
            }
            set {
                this.bodyField = value;
                this.RaisePropertyChanged("Body");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public System.Nullable<System.DateTime> StartDate {
            get {
                return this.startDateField;
            }
            set {
                this.startDateField = value;
                this.RaisePropertyChanged("StartDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public System.Nullable<System.DateTime> DueDate {
            get {
                return this.dueDateField;
            }
            set {
                this.dueDateField = value;
                this.RaisePropertyChanged("DueDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public System.Nullable<System.DateTime> Reminder {
            get {
                return this.reminderField;
            }
            set {
                this.reminderField = value;
                this.RaisePropertyChanged("Reminder");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public NuTaskPriority Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
                this.RaisePropertyChanged("Priority");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public bool IsPrivate {
            get {
                return this.isPrivateField;
            }
            set {
                this.isPrivateField = value;
                this.RaisePropertyChanged("IsPrivate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Company {
            get {
                return this.companyField;
            }
            set {
                this.companyField = value;
                this.RaisePropertyChanged("Company");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public bool Completed {
            get {
                return this.completedField;
            }
            set {
                this.completedField = value;
                this.RaisePropertyChanged("Completed");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=9)]
        public NuRequirement[] Parents {
            get {
                return this.parentsField;
            }
            set {
                this.parentsField = value;
                this.RaisePropertyChanged("Parents");
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public enum NuTaskPriority {
        
        /// <remarks/>
        Low,
        
        /// <remarks/>
        Normal,
        
        /// <remarks/>
        High,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class NuRequirement : NuTask {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class User : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Guid internalIdField;
        
        private System.DateTime createdField;
        
        private bool isBlockedField;
        
        private int maintenanceField;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string emailField;
        
        private string passwordField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public System.Guid InternalId {
            get {
                return this.internalIdField;
            }
            set {
                this.internalIdField = value;
                this.RaisePropertyChanged("InternalId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public System.DateTime Created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
                this.RaisePropertyChanged("Created");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool IsBlocked {
            get {
                return this.isBlockedField;
            }
            set {
                this.isBlockedField = value;
                this.RaisePropertyChanged("IsBlocked");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Maintenance {
            get {
                return this.maintenanceField;
            }
            set {
                this.maintenanceField = value;
                this.RaisePropertyChanged("Maintenance");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string FirstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
                this.RaisePropertyChanged("FirstName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string LastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
                this.RaisePropertyChanged("LastName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
                this.RaisePropertyChanged("Email");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://sync.today/")]
    public partial class SimpleCommunicatorConnectInfo : CommunicatorConnectInfo {
        
        private string usernameField;
        
        private string passwordField;
        
        private string serverField;
        
        private System.Guid internalIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
                this.RaisePropertyChanged("Username");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Password {
            get {
                return this.passwordField;
            }
            set {
                this.passwordField = value;
                this.RaisePropertyChanged("Password");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Server {
            get {
                return this.serverField;
            }
            set {
                this.serverField = value;
                this.RaisePropertyChanged("Server");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public System.Guid InternalId {
            get {
                return this.internalIdField;
            }
            set {
                this.internalIdField = value;
                this.RaisePropertyChanged("InternalId");
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface TaskDatabaseSoapChannel : SampleTaskConsoleApplication.TaskDatabaseServiceReference.TaskDatabaseSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TaskDatabaseSoapClient : System.ServiceModel.ClientBase<SampleTaskConsoleApplication.TaskDatabaseServiceReference.TaskDatabaseSoap>, SampleTaskConsoleApplication.TaskDatabaseServiceReference.TaskDatabaseSoap {
        
        public TaskDatabaseSoapClient() {
        }
        
        public TaskDatabaseSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TaskDatabaseSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskDatabaseSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TaskDatabaseSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account GetAccount(System.Guid accountId) {
            return base.Channel.GetAccount(accountId);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account> GetAccountAsync(System.Guid accountId) {
            return base.Channel.GetAccountAsync(accountId);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account GetAccount2(string accountId) {
            return base.Channel.GetAccount2(accountId);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account> GetAccount2Async(string accountId) {
            return base.Channel.GetAccount2Async(accountId);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[] GetTasks(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user) {
            return base.Channel.GetTasks(account, user);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[]> GetTasksAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user) {
            return base.Channel.GetTasksAsync(account, user);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[] GetTasks2(string accountId, string userInternalId) {
            return base.Channel.GetTasks2(accountId, userInternalId);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask[]> GetTasks2Async(string accountId, string userInternalId) {
            return base.Channel.GetTasks2Async(accountId, userInternalId);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask GetTask(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string id) {
            return base.Channel.GetTask(account, user, id);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> GetTaskAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string id) {
            return base.Channel.GetTaskAsync(account, user, id);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask GetTask2(string accountId, string userInternalId, string id) {
            return base.Channel.GetTask2(accountId, userInternalId, id);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> GetTask2Async(string accountId, string userInternalId, string id) {
            return base.Channel.GetTask2Async(accountId, userInternalId, id);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask SaveTask(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task) {
            return base.Channel.SaveTask(account, user, task);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> SaveTaskAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task) {
            return base.Channel.SaveTaskAsync(account, user, task);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask ChangeTaskExternalId(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string oldId, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task) {
            return base.Channel.ChangeTaskExternalId(account, user, oldId, task);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask> ChangeTaskExternalIdAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account account, SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user, string oldId, SampleTaskConsoleApplication.TaskDatabaseServiceReference.NuTask task) {
            return base.Channel.ChangeTaskExternalIdAsync(account, user, oldId, task);
        }
        
        public string GetUserSalt(string email) {
            return base.Channel.GetUserSalt(email);
        }
        
        public System.Threading.Tasks.Task<string> GetUserSaltAsync(string email) {
            return base.Channel.GetUserSaltAsync(email);
        }
        
        public bool LoginUser(SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user) {
            return base.Channel.LoginUser(user);
        }
        
        public System.Threading.Tasks.Task<bool> LoginUserAsync(SampleTaskConsoleApplication.TaskDatabaseServiceReference.User user) {
            return base.Channel.LoginUserAsync(user);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.User LoginUser2(string email, string password) {
            return base.Channel.LoginUser2(email, password);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.User> LoginUser2Async(string email, string password) {
            return base.Channel.LoginUser2Async(email, password);
        }
        
        public SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account GetAccountForClient(System.Guid userid, System.Guid clientId) {
            return base.Channel.GetAccountForClient(userid, clientId);
        }
        
        public System.Threading.Tasks.Task<SampleTaskConsoleApplication.TaskDatabaseServiceReference.Account> GetAccountForClientAsync(System.Guid userid, System.Guid clientId) {
            return base.Channel.GetAccountForClientAsync(userid, clientId);
        }
    }
}
