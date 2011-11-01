﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace DiversityService
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DiversityMobileEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DiversityMobileEntities object using the connection string found in the 'DiversityMobileEntities' section of the application configuration file.
        /// </summary>
        public DiversityMobileEntities() : base("name=DiversityMobileEntities", "DiversityMobileEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DiversityMobileEntities object.
        /// </summary>
        public DiversityMobileEntities(string connectionString) : base(connectionString, "DiversityMobileEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DiversityMobileEntities object.
        /// </summary>
        public DiversityMobileEntities(EntityConnection connection) : base(connection, "DiversityMobileEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = false;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TaxRef_BfN_VPlants> TaxRef_BfN_VPlants
        {
            get
            {
                if ((_TaxRef_BfN_VPlants == null))
                {
                    _TaxRef_BfN_VPlants = base.CreateObjectSet<TaxRef_BfN_VPlants>("TaxRef_BfN_VPlants");
                }
                return _TaxRef_BfN_VPlants;
            }
        }
        private ObjectSet<TaxRef_BfN_VPlants> _TaxRef_BfN_VPlants;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Pflanzengesellschaften> Pflanzengesellschaften
        {
            get
            {
                if ((_Pflanzengesellschaften == null))
                {
                    _Pflanzengesellschaften = base.CreateObjectSet<Pflanzengesellschaften>("Pflanzengesellschaften");
                }
                return _Pflanzengesellschaften;
            }
        }
        private ObjectSet<Pflanzengesellschaften> _Pflanzengesellschaften;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TaxRef_BfN_VPlants EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTaxRef_BfN_VPlants(TaxRef_BfN_VPlants taxRef_BfN_VPlants)
        {
            base.AddObject("TaxRef_BfN_VPlants", taxRef_BfN_VPlants);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Pflanzengesellschaften EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPflanzengesellschaften(Pflanzengesellschaften pflanzengesellschaften)
        {
            base.AddObject("Pflanzengesellschaften", pflanzengesellschaften);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DiversityMobileModel", Name="Pflanzengesellschaften")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Pflanzengesellschaften : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Pflanzengesellschaften object.
        /// </summary>
        /// <param name="propertyID">Initial value of the PropertyID property.</param>
        /// <param name="displayText">Initial value of the DisplayText property.</param>
        /// <param name="termID">Initial value of the TermID property.</param>
        public static Pflanzengesellschaften CreatePflanzengesellschaften(global::System.Int32 propertyID, global::System.String displayText, global::System.Int32 termID)
        {
            Pflanzengesellschaften pflanzengesellschaften = new Pflanzengesellschaften();
            pflanzengesellschaften.PropertyID = propertyID;
            pflanzengesellschaften.DisplayText = displayText;
            pflanzengesellschaften.TermID = termID;
            return pflanzengesellschaften;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PropertyID
        {
            get
            {
                return _PropertyID;
            }
            set
            {
                if (_PropertyID != value)
                {
                    OnPropertyIDChanging(value);
                    ReportPropertyChanging("PropertyID");
                    _PropertyID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PropertyID");
                    OnPropertyIDChanged();
                }
            }
        }
        private global::System.Int32 _PropertyID;
        partial void OnPropertyIDChanging(global::System.Int32 value);
        partial void OnPropertyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PropertyURI
        {
            get
            {
                return _PropertyURI;
            }
            set
            {
                OnPropertyURIChanging(value);
                ReportPropertyChanging("PropertyURI");
                _PropertyURI = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PropertyURI");
                OnPropertyURIChanged();
            }
        }
        private global::System.String _PropertyURI;
        partial void OnPropertyURIChanging(global::System.String value);
        partial void OnPropertyURIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String DisplayText
        {
            get
            {
                return _DisplayText;
            }
            set
            {
                if (_DisplayText != value)
                {
                    OnDisplayTextChanging(value);
                    ReportPropertyChanging("DisplayText");
                    _DisplayText = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("DisplayText");
                    OnDisplayTextChanged();
                }
            }
        }
        private global::System.String _DisplayText;
        partial void OnDisplayTextChanging(global::System.String value);
        partial void OnDisplayTextChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HierarchyCache
        {
            get
            {
                return _HierarchyCache;
            }
            set
            {
                OnHierarchyCacheChanging(value);
                ReportPropertyChanging("HierarchyCache");
                _HierarchyCache = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HierarchyCache");
                OnHierarchyCacheChanged();
            }
        }
        private global::System.String _HierarchyCache;
        partial void OnHierarchyCacheChanging(global::System.String value);
        partial void OnHierarchyCacheChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TermID
        {
            get
            {
                return _TermID;
            }
            set
            {
                if (_TermID != value)
                {
                    OnTermIDChanging(value);
                    ReportPropertyChanging("TermID");
                    _TermID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("TermID");
                    OnTermIDChanged();
                }
            }
        }
        private global::System.Int32 _TermID;
        partial void OnTermIDChanging(global::System.Int32 value);
        partial void OnTermIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> BroaderTermID
        {
            get
            {
                return _BroaderTermID;
            }
            set
            {
                OnBroaderTermIDChanging(value);
                ReportPropertyChanging("BroaderTermID");
                _BroaderTermID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BroaderTermID");
                OnBroaderTermIDChanged();
            }
        }
        private Nullable<global::System.Int32> _BroaderTermID;
        partial void OnBroaderTermIDChanging(Nullable<global::System.Int32> value);
        partial void OnBroaderTermIDChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DiversityMobileModel", Name="TaxRef_BfN_VPlants")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TaxRef_BfN_VPlants : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TaxRef_BfN_VPlants object.
        /// </summary>
        /// <param name="nameURI">Initial value of the NameURI property.</param>
        /// <param name="genusOrSupragenericName">Initial value of the GenusOrSupragenericName property.</param>
        /// <param name="synonymy">Initial value of the Synonymy property.</param>
        public static TaxRef_BfN_VPlants CreateTaxRef_BfN_VPlants(global::System.String nameURI, global::System.String genusOrSupragenericName, global::System.String synonymy)
        {
            TaxRef_BfN_VPlants taxRef_BfN_VPlants = new TaxRef_BfN_VPlants();
            taxRef_BfN_VPlants.NameURI = nameURI;
            taxRef_BfN_VPlants.GenusOrSupragenericName = genusOrSupragenericName;
            taxRef_BfN_VPlants.Synonymy = synonymy;
            return taxRef_BfN_VPlants;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NameURI
        {
            get
            {
                return _NameURI;
            }
            set
            {
                if (_NameURI != value)
                {
                    OnNameURIChanging(value);
                    ReportPropertyChanging("NameURI");
                    _NameURI = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("NameURI");
                    OnNameURIChanged();
                }
            }
        }
        private global::System.String _NameURI;
        partial void OnNameURIChanging(global::System.String value);
        partial void OnNameURIChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TaxonNameCache
        {
            get
            {
                return _TaxonNameCache;
            }
            set
            {
                OnTaxonNameCacheChanging(value);
                ReportPropertyChanging("TaxonNameCache");
                _TaxonNameCache = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TaxonNameCache");
                OnTaxonNameCacheChanged();
            }
        }
        private global::System.String _TaxonNameCache;
        partial void OnTaxonNameCacheChanging(global::System.String value);
        partial void OnTaxonNameCacheChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String TaxonNameSinAuthors
        {
            get
            {
                return _TaxonNameSinAuthors;
            }
            set
            {
                OnTaxonNameSinAuthorsChanging(value);
                ReportPropertyChanging("TaxonNameSinAuthors");
                _TaxonNameSinAuthors = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("TaxonNameSinAuthors");
                OnTaxonNameSinAuthorsChanged();
            }
        }
        private global::System.String _TaxonNameSinAuthors;
        partial void OnTaxonNameSinAuthorsChanging(global::System.String value);
        partial void OnTaxonNameSinAuthorsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String GenusOrSupragenericName
        {
            get
            {
                return _GenusOrSupragenericName;
            }
            set
            {
                OnGenusOrSupragenericNameChanging(value);
                ReportPropertyChanging("GenusOrSupragenericName");
                _GenusOrSupragenericName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("GenusOrSupragenericName");
                OnGenusOrSupragenericNameChanged();
            }
        }
        private global::System.String _GenusOrSupragenericName;
        partial void OnGenusOrSupragenericNameChanging(global::System.String value);
        partial void OnGenusOrSupragenericNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SpeciesEpithet
        {
            get
            {
                return _SpeciesEpithet;
            }
            set
            {
                OnSpeciesEpithetChanging(value);
                ReportPropertyChanging("SpeciesEpithet");
                _SpeciesEpithet = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SpeciesEpithet");
                OnSpeciesEpithetChanged();
            }
        }
        private global::System.String _SpeciesEpithet;
        partial void OnSpeciesEpithetChanging(global::System.String value);
        partial void OnSpeciesEpithetChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String InfraspecificEpithet
        {
            get
            {
                return _InfraspecificEpithet;
            }
            set
            {
                OnInfraspecificEpithetChanging(value);
                ReportPropertyChanging("InfraspecificEpithet");
                _InfraspecificEpithet = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("InfraspecificEpithet");
                OnInfraspecificEpithetChanged();
            }
        }
        private global::System.String _InfraspecificEpithet;
        partial void OnInfraspecificEpithetChanging(global::System.String value);
        partial void OnInfraspecificEpithetChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Synonymy
        {
            get
            {
                return _Synonymy;
            }
            set
            {
                OnSynonymyChanging(value);
                ReportPropertyChanging("Synonymy");
                _Synonymy = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Synonymy");
                OnSynonymyChanged();
            }
        }
        private global::System.String _Synonymy;
        partial void OnSynonymyChanging(global::System.String value);
        partial void OnSynonymyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Family
        {
            get
            {
                return _Family;
            }
            set
            {
                OnFamilyChanging(value);
                ReportPropertyChanging("Family");
                _Family = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Family");
                OnFamilyChanged();
            }
        }
        private global::System.String _Family;
        partial void OnFamilyChanging(global::System.String value);
        partial void OnFamilyChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Order
        {
            get
            {
                return _Order;
            }
            set
            {
                OnOrderChanging(value);
                ReportPropertyChanging("Order");
                _Order = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Order");
                OnOrderChanged();
            }
        }
        private global::System.String _Order;
        partial void OnOrderChanging(global::System.String value);
        partial void OnOrderChanged();

        #endregion
    
    }

    #endregion
    
}