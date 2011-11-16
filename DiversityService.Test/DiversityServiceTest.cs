﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using DiversityService.Model;

namespace DiversityService.Test
{
    public class DiversityServiceTest
    {
        private IDiversityService _target;
        public DiversityServiceTest()
        {
            _target = new DiversityService();
        }

        [Fact]
        public void svc_should_insert_single_event_hierarchy()
        {
            //Prepare
            var hierarchy = new HierarchySection()
            {
                Event = new Event()
                {
                    EventID = 0,
                    SeriesID = null,
                    LocalityDescription = "TestLocality",
                    HabitatDescription = "TestHabitat",
                    CollectionDate = new DateTime(2001,01,02)                                        
                }
            };

            //Execute
            var updatedHierarchy = _target.InsertHierarchy(hierarchy);
            var updatedEvent = updatedHierarchy.Event;

            
            var ctx = new DiversityCollection.DiversityCollection_BaseTestEntities();
            var addedEntity = ( from ev in ctx.CollectionEvent
                                where ev.CollectionEventID == updatedEvent.EventID
                                select ev).FirstOrDefault();

            //Cleanup
            if (addedEntity != null)
            {
                ctx.CollectionEvent.DeleteObject(addedEntity);
                ctx.SaveChanges();
            }


            //Assert
            Assert.NotNull(addedEntity); 

        }

    }
}