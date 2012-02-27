﻿namespace DiversityPhone.Model
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    using DiversityPhone.Services;
    using Svc = DiversityPhone.DiversityService;

    [Table]
    public class EventSeries : IModifyable
    {
        private static EventSeries _NoEventSeries;

        public EventSeries()
        {
            this.Description = string.Empty;
            this.SeriesCode = string.Empty;
            this.SeriesStart = DateTime.Now;
            this.SeriesEnd = null;
            this.SeriesID = 0;
            this.LogUpdatedWhen = DateTime.Now;
            this.ModificationState = null;
            this.DiversityCollectionEventSeriesID = null;
            this.GeoSource = null;//ToDo/Tabelle File für Geodaten anlegen
            //_Events = new EntitySet<Event>(
            //    new Action<Event>(Attach_Event),
            //    new Action<Event>(Detach_Event));

        }


        public static EventSeries NoEventSeries
        {
            get
            {
                return _NoEventSeries;
            }
        }

        public static bool isNoEventSeries(EventSeries es)
        {
            return _NoEventSeries == es;
        }

        [Column(IsPrimaryKey = true)]
        public int SeriesID { get; set; }

        [Column(CanBeNull = true)]
        public int? DiversityCollectionEventSeriesID { get; set; }

        [Column(CanBeNull = false)]
        public string Description { get; set; }

        [Column]
        public string GeoSource { get; set; }

        [Column]
        public string SeriesCode { get; set; }

        [Column]
        public DateTime SeriesStart { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? SeriesEnd { get; set; }

       

        /// <summary>
        /// Tracks modifications to this Object.
        /// is null for newly created Objects
        /// </summary>
        [Column(CanBeNull = true)]
        public bool? ModificationState { get; set; }

        [Column]
        public DateTime LogUpdatedWhen { get; set; }



        public static IQueryOperations<EventSeries> Operations
        {
            get;
            private set;
        }

        static EventSeries()
        {
            Operations = new QueryOperations<EventSeries>(
                //Smallerthan
                          (q, es) => q.Where(row => row.SeriesID < es.SeriesID),
                //Equals
                          (q, es) => q.Where(row => row.SeriesID == es.SeriesID),
                //Orderby
                          (q) => q.OrderBy(es => -es.SeriesID),//As EventSeries have negative Values Unlike the other entities in DiversityCollection we need to order by the nagtive value to get the same behaviour
                //FreeKey
                          (q, es) =>
                          {
                              es.SeriesID = QueryOperations<EventSeries>.FindFreeIntKeyUp(q, row => row.SeriesID);//CollectionEventSeries Autoinc-key is lowered by one by default in DiversityCollection. As we need to avoid Synchronisationconflicts we need to count in the other direction.
                          });

            _NoEventSeries = new EventSeries()
            {
                Description = "Events",
                SeriesCode = "No EventSeries",
                ModificationState = false
            };
        }



        //public static EventSeries Clone(EventSeries es)
        //{
        //    EventSeries clone = new EventSeries();
        //    clone.Description = es.Description;
        //    clone.GeoSource = es.GeoSource;
        //    clone.LogUpdatedWhen = es.LogUpdatedWhen;
        //    clone.ModificationState = es.ModificationState;
        //    clone.SeriesCode = es.SeriesCode;
        //    clone.SeriesEnd = es.SeriesEnd;
        //    clone.SeriesID = es.SeriesID;
        //    clone.SeriesStart = es.SeriesStart;
        //    return clone;

        //}

        public static Svc.EventSeries ConvertToServiceObject(EventSeries es)
        {

            Svc.EventSeries export = new Svc.EventSeries();
            export.SeriesID = es.SeriesID;
            export.DiversityCollectionEventSeriesID = es.DiversityCollectionEventSeriesID;
            export.SeriesCode = es.SeriesCode;
            export.SeriesStart = es.SeriesStart;
            export.SeriesEnd = es.SeriesEnd;
            export.Description = es.Description;
            export.LogUpdatedWhen = es.LogUpdatedWhen;
            //Todo: export.Geography = EventSeries.convertGeoSourceToString(es.GeoSource);
            return export;

        }

        public static String convertGeoSourceToString(String path)
        {
            throw new NotImplementedException();
        }

        #region Associations
        //private EntitySet<Event> _Events;
        //[Association(Name = "FK_Series_Event",
        //             Storage = "_Events",
        //             ThisKey = "SeriesID",
        //             OtherKey = "SeriesID",
        //             IsForeignKey = true)]
        //public EntitySet<Event> Events
        //{
        //    get { return _Events; }
        //    set { _Events.Assign(value); }
        //}

        //private void Attach_Event(Event entity)
        //{
        //    entity.EventSeries = this;
        //}

        //private void Detach_Event(Event entity)
        //{
        //    entity.EventSeries = null;
        //}
        #endregion

    }
}
