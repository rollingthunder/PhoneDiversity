﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiversityService.Model;


namespace DiversityPhone
{
    public interface IOfflineStorage
    {
        IList<EventSeries> EventSeries { get; }
        //IList<Event> Events { get; }
        //IList<IdentificationUnit> IdentificationUnits { get; }
    }
}