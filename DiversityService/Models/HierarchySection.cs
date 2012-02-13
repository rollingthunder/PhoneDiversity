﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DiversityService.Model
{
    
    public class HierarchySection
    {
        //Wird nicht synchroniniert. Enthält Informationen über den Sammler
        public UserProfile Profile { get; set; }

        //Nur Modelklassen. Abgeleitet Serverklassen stehen im Kommentar
        public Event Event { get; set; }
        //->CollectionEventLocalisation
        public IList<CollectionEventProperty> Properties { get; set; }

        public IList<Specimen> Specimen { get; set; }
        //->Project
        //->Agent

        public IList<IdentificationUnit> IdentificationUnits { get; set; }
        //->Identification
        //->IdentificationUnitGeoAnalysis

        public IList<IdentificationUnitAnalysis> Analyses { get; set; }
    }
}
