﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiversityPhone.Services
{
    public interface IGeoLocationService
    {
        void fillGeoCoordinates(Model.ILocalizable loc);        
    }
}
