﻿namespace DiversityPhone.Services
{
using System;
using System.Linq;
using System.Collections.Generic;
using DiversityPhone.Model;
using ReactiveUI;
using DiversityPhone.Messages;
using DiversityPhone.Utility;
using DiversityPhone.Common;
using System.Data.Linq;
using System.Linq.Expressions;
using Svc = DiversityPhone.Service;

    public class OfflineStorage : IOfflineStorage
    {
        private IList<IDisposable> _subscriptions;
        private IMessageBus _messenger;

        public OfflineStorage(IMessageBus messenger)
        {
            this._messenger = messenger;

            _subscriptions = new List<IDisposable>()
            {
                

                _messenger.Listen<EventSeries>(MessageContracts.SAVE)
                    .Subscribe(es => addOrUpdateEventSeries(es)),
                _messenger.Listen<EventSeries>(MessageContracts.DELETE)
                    .Subscribe(es => deleteEventSeries(es)),
                _messenger.Listen<Event>(MessageContracts.SAVE)
                    .Subscribe(ev => addOrUpdateEvent(ev)),

                _messenger.Listen<Specimen>(MessageContracts.SAVE)
                    .Subscribe(spec => addOrUpdateSpecimen(spec)),

                _messenger.Listen<IdentificationUnit>(MessageContracts.SAVE)
                    .Subscribe(iu => addOrUpdateIUnit(iu)),
            };

            using (var context = new DiversityDataContext())
            {
                if (!context.DatabaseExists())
                    context.CreateDatabase();
            }
        }

        #region UserProfile

        public IList<UserProfile> getAllUserProfiles()
        {
            return uncachedQuery(ctx => ctx.Profiles);
        }
        public UserProfile getUserProfile(string loginName)
        {
            return singletonQuery(ctx => ctx.Profiles, p => p.LoginName == loginName);
        }

        #endregion

        #region EventSeries

        private IList<EventSeries> esQuery(Expression<Func<EventSeries, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx => 
                {
                    if(restriction == null)
                        return (from es in ctx.EventSeries
                                select es);
                    else
                        return (from es in ctx.EventSeries
                                select es).Where(restriction);
                },
                es => es.SeriesID);
        }

        public IList<EventSeries> getAllEventSeries()
        {
            return esQuery();
        }

        public IList<EventSeries> getNewEventSeries()
        {
           return esQuery(es => es.IsModified == null);
        }

        public EventSeries getEventSeriesByID(int id)
        {
            EventSeries result = null;
            withDataContext((ctx) =>
                {
                    result = (from es in ctx.EventSeries
                              where es.SeriesID == id
                              select es).FirstOrDefault();
                });
            return result;
        }       

        public void addOrUpdateEventSeries(global::DiversityPhone.Model.EventSeries newSeries)
        {
            if (EventSeries.isNoEventSeries(newSeries))
                return;

            addOrUpdateRow(
                ctx => ctx.EventSeries, 
                es => es.SeriesID, 
                (es,id) => es.SeriesID = id, 
                newSeries);
        }

        public void deleteEventSeries(EventSeries toDeleteEs)
        {
            deleteRow(ctx => ctx.EventSeries, es => es.SeriesID, toDeleteEs);
        }

        #endregion

        #region Event

        private IList<Event> evQuery(Expression<Func<Event, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx =>
            {
                if (restriction == null)
                    return (from ev in ctx.Events
                            select ev);
                else
                    return (from ev in ctx.Events
                            select ev).Where(restriction);
            },
                ev => ev.EventID);
        }

        public IList<Event> getAllEvents()
        {
            return evQuery();

        }


        public IList<Event> getEventsForSeries(EventSeries es)
        {
            return evQuery(ev => ev.SeriesID == es.SeriesID);
        }

        public IList<Event> getEventsWithoutSeries()
        {
            return evQuery(ev => ev.SeriesID == null);
        }

        private static int findFreeEventID(DiversityDataContext ctx)
        {
            int min = -1;
            if (ctx.Events.Any())
                min = (from ev in ctx.Events select ev.EventID).Min();
            return (min > -1) ? -1 : min - 1;
        }

        public void addOrUpdateEvent(Event ev)
        {
            using (var ctx = new DiversityDataContext())
            {
                if (ev.IsModified == null)
                    ev.EventID = findFreeEventID(ctx);
                ev.LogUpdatedWhen = DateTime.Now;
                ctx.Events.InsertOnSubmit(ev);
                ctx.SubmitChanges();
            }
        }
        #endregion

        #region CollectionEventProperties

        private IList<CollectionEventProperty> cepQuery(Expression<Func<CollectionEventProperty, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx =>
            {
                if (restriction == null)
                    return (from cep in ctx.CollectionEventProperties
                            select cep);
                else
                    return (from cep in ctx.CollectionEventProperties
                            select cep).Where(restriction);
            },
                cep => cep.PropertyID);
        }

        public IList<CollectionEventProperty> getPropertiesForEvent(Event ev)
        {
            return cepQuery(cep => cep.EventID == ev.EventID);
        }

        public void addOrUpdateCollectionEventProperty(CollectionEventProperty cep)
        {
            using (var ctx = new DiversityDataContext())
            {
                cep.LogUpdatedWhen = DateTime.Now;
                ctx.CollectionEventProperties.InsertOnSubmit(cep);
                ctx.SubmitChanges();
            }
        }

        public IList<Property> getAllProperties()
        {
            return uncachedQuery(ctx => from p in ctx.Properties
                                 select p);
        }

        public Property getPropertyByID(int id)
        {
            Property result = null;
            withDataContext(ctx =>
                {
                    result = (from prop in ctx.Properties
                            where prop.PropertyID == id
                            select prop).FirstOrDefault();
                });
            return result;
        }
        #endregion


        #region Specimen
        private IList<Specimen> specQuery(Expression<Func<Specimen, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx =>
            {
                var q = (from spec in ctx.Specimen
                         select spec);
                if (restriction == null)
                    return q;
                else
                    return q.Where(restriction);
            },
                spec => spec.CollectionSpecimenID);
        }
        public IList<Specimen> getAllSpecimen()
        {
            return specQuery();
        }

        public IList<Specimen> getSpecimenForEvent(Event ev)
        {
            return specQuery(spec => spec.CollectionEventID == ev.EventID);
        }

        public IList<Specimen> getSpecimenWithoutEvent()
        {
            return specQuery(spec => spec.CollectionEventID == null);
        }

        private static int findFreeSpecimenID(DiversityDataContext ctx)
        {
            int min = -1;
            if (ctx.Specimen.Any())
                min = (from spec in ctx.Specimen select spec.CollectionSpecimenID).Min();
            return (min > -1) ? -1 : min - 1;
        }

        public void addOrUpdateSpecimen(Specimen spec)
        {
            using (var ctx = new DiversityDataContext())
            {
                if (spec.IsModified == null)
                {
                    spec.CollectionSpecimenID = findFreeSpecimenID(ctx);
                    ctx.Specimen.InsertOnSubmit(spec);
                }
                
                ctx.SubmitChanges();
            }
        }

        #endregion

        #region IdentificationUnit

        private IList<IdentificationUnit> iuQuery(Expression<Func<IdentificationUnit, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx =>
            {
                if (restriction == null)
                    return (from iu in ctx.IdentificationUnits
                            select iu);
                else
                    return (from iu in ctx.IdentificationUnits
                            select iu).Where(restriction);
            },
                iu => iu.UnitID);
        }

        public IList<IdentificationUnit> getTopLevelIUForSpecimen(Specimen spec)
        {
            return iuQuery(iu => iu.SpecimenID == spec.CollectionSpecimenID && iu.RelatedUnitID == null);            
        }


        public IList<IdentificationUnit> getSubUnits(IdentificationUnit unit)
        {
            return iuQuery(iu => iu.RelatedUnitID == unit.UnitID);
        }

        public IdentificationUnit getIdentificationUnitByID(int id)
        {
            IdentificationUnit result = null;
            withDataContext((ctx) =>
                {
                    result = (from iu in ctx.IdentificationUnits
                              where iu.UnitID == id
                              select iu).FirstOrDefault();
                });
            return result;
        }

        private static int findFreeUnitID(DiversityDataContext ctx)
        {
            int min = -1;
            if (ctx.IdentificationUnits.Any())
                min = (from iu in ctx.IdentificationUnits select iu.UnitID).Min();
            return (min > -1) ? -1 : min - 1;
        }

        public void addOrUpdateIUnit(IdentificationUnit iu)
        {
            using (var ctx = new DiversityDataContext())
            {
                if (iu.IsModified == null)
                    iu.UnitID = findFreeUnitID(ctx);
                ctx.IdentificationUnits.InsertOnSubmit(iu);
                ctx.SubmitChanges();
            }
        }

        #endregion

        #region Analyses

        private IList<IdentificationUnitAnalysis> iuanQuery(Expression<Func<IdentificationUnitAnalysis, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx =>
            {
                if (restriction == null)
                    return (from iuan in ctx.IdentificationUnitAnalyses
                            select iuan);
                else
                    return (from iuan in ctx.IdentificationUnitAnalyses
                            select iuan).Where(restriction);
            },
                iuan => iuan.IdentificationUnitAnalysisID);
        }


        public IList<IdentificationUnitAnalysis> getIUAForIU(IdentificationUnit iu)
        {
            return iuanQuery(iuan => iuan.IdentificationUnitID == iu.UnitID);
        }

        private static int findFreeIUAnalysisID(DiversityDataContext ctx)
        {
            int min = -1;
            if (ctx.IdentificationUnitAnalyses.Any())
                min = (from iua in ctx.IdentificationUnitAnalyses select iua.IdentificationUnitAnalysisID).Min();
            return (min > -1) ? -1 : min - 1;
        }

        public void addOrUpdateIUA(IdentificationUnitAnalysis iua)
        {
            using (var ctx = new DiversityDataContext())
            {
                if (iua.IsModified == null)
                    iua.IdentificationUnitAnalysisID = findFreeIUAnalysisID(ctx);
                ctx.IdentificationUnitAnalyses.InsertOnSubmit(iua);
                ctx.SubmitChanges();
            }
        }

        private IList<Analysis> anQuery(Expression<Func<Analysis, bool>> restriction = null)
        {
            return cachedIntKeyedQuery(ctx =>
            {
                if (restriction == null)
                    return (from an in ctx.Analyses
                            select an);
                else
                    return (from an in ctx.Analyses
                            select an).Where(restriction);
            },
                an => an.AnalysisID);
        }

        public IList<Analysis> getAllAnalyses()
        {
            return anQuery();
        }

        public IList<Analysis> getPossibleAnalyses(string taxonomicGroup)
        {
            return cachedIntKeyedQuery(ctx =>
                from an in ctx.Analyses
                join atg in ctx.AnalysisTaxonomicGroups on an.AnalysisID equals atg.AnalysisID
                where atg.TaxonomicGroup == taxonomicGroup
                select an,
                an => an.AnalysisID);
        }

        public Analysis getAnalysisByID(int id)
        {
            Analysis result = null;
            withDataContext((ctx) =>
                {
                    result = (from an in ctx.Analyses
                              where an.AnalysisID == id
                              select an).FirstOrDefault();
                });
            return result;
        }

        public void addAnalyses(IEnumerable<Analysis> analyses)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.Analyses.InsertAllOnSubmit(analyses);
                ctx.SubmitChanges();
            }
        }       

        public IList<AnalysisResult> getPossibleAnalysisResults(int analysisID)
        {
            return cachedIntKeyedQuery(ctx =>            
                from ar in ctx.AnalysisResults
                where ar.AnalysisID == analysisID
                select ar,
                ar => ar.Result.GetHashCode());
        }
        public void addAnalysisResults(IEnumerable<AnalysisResult> results)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.AnalysisResults.InsertAllOnSubmit(results);
                ctx.SubmitChanges();
            }
        }
        

        public void addAnalysisTaxonomicGroups(IEnumerable<AnalysisTaxonomicGroup> groups)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.AnalysisTaxonomicGroups.InsertAllOnSubmit(groups);
                ctx.SubmitChanges();
            }
        }
        
      

        #endregion

        #region Multimedia        

        public IList<MultimediaObject> getAllMultimediaObjects()
        {
            return uncachedQuery(ctx => ctx.MultimediaObjects);
        }

        public IList<MultimediaObject> getMultimediaForEventSeries(EventSeries es)
        {
            return uncachedQuery(ctx => from mm in ctx.MultimediaObjects
                                        where mm.SourceId == (int)SourceID.EventSeries
                                                && mm.RelatedId == es.SeriesID
                                        select mm);
        }

      
        public IList<MultimediaObject> getMultimediaForEvent(Event ev)
        {
            return uncachedQuery(ctx => from mm in ctx.MultimediaObjects
                                        where mm.SourceId == (int)SourceID.Event
                                                && mm.RelatedId == ev.EventID
                                        select mm);            
        }


        public IList<MultimediaObject> getMultimediaForSpecimen(Specimen spec)
        {
            return uncachedQuery(ctx => from mm in ctx.MultimediaObjects
                                        where mm.SourceId == (int)SourceID.Specimen
                                                && mm.RelatedId == spec.CollectionSpecimenID
                                        select mm);
        }

        public IList<MultimediaObject> getMultimediaForIdentificationUnit(IdentificationUnit iu)
        {
            return uncachedQuery(ctx => from mm in ctx.MultimediaObjects
                                        where mm.SourceId == (int)SourceID.IdentificationUnit
                                                && mm.RelatedId == iu.UnitID
                                        select mm);
        }

        public void addMultimediaObject(MultimediaObject mmo)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.MultimediaObjects.InsertOnSubmit(mmo);
                ctx.SubmitChanges();
            }
        }
        #endregion

        #region Terms

        public IList<Term> getTerms(int source)
        {
            return uncachedQuery(ctx => from t in ctx.Terms
                                        where t.SourceID == source
                                        select t);
        }

     

        public void addTerms(IEnumerable<Term> terms)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.Terms.InsertAllOnSubmit(terms);
                ctx.SubmitChanges();
            }

            sampleData();
        }

        #endregion

        #region TaxonNames   
     
        public void addTaxonNames(IEnumerable<TaxonName> taxa, int tableID)
        {
            throw new NotImplementedException();
        }

        private Table<TaxonName> getTaxonTable(DiversityDataContext ctx, int tableID)
        {
            switch (tableID)
                {
                    case 0: return ctx.TaxonNames0;                        
                    case 1: return ctx.TaxonNames1;                        
                    case 2: return ctx.TaxonNames2;                        
                    case 3: return ctx.TaxonNames3;                        
                    case 4: return ctx.TaxonNames4;                        
                    case 5: return ctx.TaxonNames5;                        
                    case 6: return ctx.TaxonNames6;                        
                    case 7: return ctx.TaxonNames7;                        
                    case 8: return ctx.TaxonNames8;                        
                    case 9: return ctx.TaxonNames9;                        
                    default:
                        throw new IndexOutOfRangeException("Only 10 tables are supported. Id is not between 0 and 9");
                }   
        }

        public IList<TaxonName> getTaxonNames(int tableID)
        {
            return cachedOrderedQuery(ctx => getTaxonTable(ctx, tableID), (tax) => ((t) => t.URI == tax.URI));
        }

        private int getTaxonTableIDForGroup(Term taxonGroup)
        {
            int id = -1;
            withDataContext(ctx =>
                {
                    var assignment = from a in ctx.taxonSelection
                                     where a.tableName == taxonGroup.Code && a.isSelected                                     
                                     select a.tableID;
                    if (assignment.Any())
                        id = assignment.First();
                });
            return id;
        }

        public IList<TaxonName> getTaxonNames(Term taxonGroup)
        {
            int tableID = getTaxonTableIDForGroup(taxonGroup);

            if (tableID == -1)
            {
                return new List<TaxonName>();
                //TODO Logging?
            }
            else
                return getTaxonNames(tableID);
        }

        #endregion

        #region PropertyNames

        public void addPropertyNames(IEnumerable<PropertyName> properties)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.PropertyNames.InsertAllOnSubmit(properties);
                ctx.SubmitChanges();
            }
        }

        public IList<PropertyName> getPropertyNames(Property prop)
        {
            return uncachedQuery(ctx =>  from pn in ctx.PropertyNames
                                         where pn.PropertyID == prop.PropertyID                                         
                                         select pn);
        }

        public PropertyName getPropertyNameByURI(string uri)
        {
            PropertyName result = null;

            withDataContext(ctx =>
                {
                    result = (from pn in ctx.PropertyNames
                              where pn.PropertyUri == uri
                              select pn).FirstOrDefault();
                });
            return result;
        }

        #endregion

        #region Maps

        public IList<Map> getAllMaps()
        {
            return uncachedQuery(ctx => from m in ctx.Maps
                                 select m);
        }
        public IList<Map> getMapsForRectangle(double latitudeNorth, double latitudeSouth, double longitudeWest, double longitudeEast)
        {
            throw new NotImplementedException();
        }

        public void addMap(Map map)
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.Maps.InsertOnSubmit(map);
                ctx.SubmitChanges();
            }
        }
        #endregion


        #region SampleData
        private void sampleData()
        {
            using (var ctx = new DiversityDataContext())
            {
                ctx.EventSeries.InsertOnSubmit(new Model.EventSeries() { SeriesID = 1, Description = "ES" });
                ctx.Events.InsertOnSubmit(new Model.Event() { SeriesID = 0, EventID = 0, LocalityDescription = "EV" });
                ctx.Specimen.InsertOnSubmit(new Model.Specimen() { CollectionEventID = 0, CollectionSpecimenID = 0, AccesionNumber = "CS" });
                ctx.IdentificationUnits.InsertOnSubmit(new IdentificationUnit() { SpecimenID = 0, UnitID = 0 });
                int id = 1;
                recSample(0, 0, ref id, ctx);
                ctx.SubmitChanges();
            }

        }
        private void recSample(int depth, int parent, ref int id, DiversityDataContext ctx)
        {
            if (depth == 3)
                return;

            depth++;
            int p = id;


            for (int i = 0; i < 20; i++)
            {
                ctx.IdentificationUnits.InsertOnSubmit(new IdentificationUnit() { UnitID = id,  RelatedUnitID = parent });
                recSample(depth, id++, ref id, ctx);
            }
        }

        #endregion     
    
        #region Generische Implementierungen
        private void addOrUpdateRow<T>(QueryParameters<T> param, T row ) where T : class
        {
            var ops = param.Operations;
            withDataContext((ctx) =>
                {
                    var table = param.TableProvider(ctx);
                    var allRowsQuery = table as IQueryable<T>;
                    var existingRow = ops.WhereKeyEquals(allRowsQuery, row)
                        .FirstOrDefault();

                    if (existingRow != null)
                        table.Attach(row, existingRow);
                    else
                    {
                        ops.SetFreeKeyOnItem(allRowsQuery, row);
                        table.InsertOnSubmit(row);
                    }

                    ctx.SubmitChanges();
                });
        }

        private void deleteRow<T>( QueryParams<T> param, T detachedRow) where T : class
        {
            var ops = param.Operations;
            withDataContext(ctx =>
                {
                    var table = param.TableProvider(ctx);
                    var attachedRow = ops.WhereKeyEquals(table, detachedRow)
                        .FirstOrDefault();

                    if (attachedRow != null)
                    {
                        table.DeleteOnSubmit(attachedRow);
                        ctx.SubmitChanges();
                    }
                });
        }

        private T singletonQuery<T>(Func<DiversityDataContext,Table<T>> tableProvider, Expression<Func<T, bool>> predicate)
        {
            T result = default(T);
            withDataContext(ctx =>
                {
                    var table = tableProvider(ctx);
                    result = table.Where(predicate)
                        .FirstOrDefault();
                });
            return result;
        }
        

        private void withDataContext(Action<DiversityDataContext> operation)
        {
            using (var ctx = new DiversityDataContext())
                operation(ctx);
        }
      
        private IList<T> cachedOrderedQuery<T>(Func<DiversityDataContext, IQueryable<T>> orderedQuery, Func<T, Expression<Func<T, bool>>> equalsTest) where T : class
        {
            return new RotatingCache<T>(new OrderedQueryCacheSource<T>(orderedQuery, equalsTest));
        }

        private IList<T> cachedIntKeyedQuery<T>(Func<DiversityDataContext, IQueryable<T>> query, Expression<Func<T, int>> KeyExpression) where T : class
        {
            return new RotatingCache<T>(new IntKeyedCacheSource<T>(query,KeyExpression));
        }

        private IList<T> uncachedQuery<T>(Func<DiversityDataContext, IQueryable<T>> query)
        {
            IList<T> result = null;
            withDataContext(ctx => result = query(ctx).ToList());
            return result;
        }


        private class IntKeyedCacheSource<T> : ICacheSource<T>
        {
            Func<DiversityDataContext, IQueryable<T>> queryFunc;
            Expression<Func<T, int>> keyExpression;
            Func<T, int> keyFunc;

            public IntKeyedCacheSource(Func<DiversityDataContext, IQueryable<T>> QueryFunc, Expression<Func<T,int>> KeyExpression)
            {
                queryFunc = QueryFunc;
                keyExpression = KeyExpression;
                keyFunc = keyExpression.Compile();                
            }

            public IEnumerable<T> retrieveItems(int count, int offset)
            {
                using (var ctx = new DiversityDataContext())
                {
                    return queryFunc(ctx)
                        .OrderBy(keyExpression)
                        .Skip(offset)
                        .Take(count)
                        .ToList(); //Force execution of query
                }
            }

            public int Count
            {
                get 
                {
                    using (var ctx = new DiversityDataContext())
                    {
                        return queryFunc(ctx)
                            .Count();
                    }
                }
            }
        

            public int  IndexOf(T item)
            {                
                var lessThanKeyExpression = LessThanKeyExpression(keyExpression, item);


                using (var ctx = new DiversityDataContext())
                {
                    return queryFunc(ctx)
                        .OrderBy(keyExpression)
                        .Where(lessThanKeyExpression)
                        .Count();
                }
            }        

        }

        private class OrderedQueryCacheSource<T> : ICacheSource<T>
        {
            private Func<DiversityDataContext, IQueryable<T>> orderedQuery;
            private Func<T, Expression<Func<T, bool>>> equalsTest;

            public OrderedQueryCacheSource(QueryParameters<T> param)
            {
                // TODO: Complete member initialization
                this.orderedQuery = orderedQuery;
                this.equalsTest = equalsTest;
            }


            public IEnumerable<T> retrieveItems(int count, int offset)
            {
                using (var ctx = new DiversityDataContext())
                {
                    return orderedQuery(ctx)
                        .Skip(offset)
                        .Take(count)
                        .ToList();
                }
            }

            public int IndexOf(T item)
            {
                using (var ctx = new DiversityDataContext())
                {
                    return orderedQuery(ctx)
                        .TakeWhile(NotExpression(equalsTest(item)))
                        .Count();
                }
            }

            public int Count
            {
                get 
                {
                    using (var ctx = new DiversityDataContext())
                    {
                        return orderedQuery(ctx).Count();
                    }
                }
            }
        }
        private delegate Table<T> TableProvider<T>(DiversityDataContext ctx);

        private class QueryParams<T> : Tuple<TableProvider<T>,IQueryOperations<T>>
        {
            public TableProvider<T> TableProvider
            {get{return this.Item1;}}
            public IQueryOperations<T> Operations
            {
                get{return this.Item2;}
            }

        }
        
        #endregion

        #region IOfflineFieldData Members

        public Svc.HierarchySection getNewHierarchyBelow(Event ev)
        {
            throw new NotImplementedException();
        }

        public void updateHierarchy(Svc.HierarchySection from, Svc.HierarchySection to)
        {
            throw new NotImplementedException();
        }

        #endregion


     
    }
}
