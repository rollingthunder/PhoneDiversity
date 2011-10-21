﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiversityService.Model
{
    public class Project
    {
        //Read-Only
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
