﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Wintellect.Sterling.Database;
using System.Collections.Generic;
using SterlingToLINQ.DiversityService;

namespace SterlingToLINQ.Sterling
{
    public class DiversityDatabase : BaseDatabaseInstance
    {
        public override string Name
        {
            get
            {
                return "DiversityDatabase";
            }
        }

        protected override List<ITableDefinition> RegisterTables()
        {
            var ceTable = CreateTableDefinition<CollectionEvent, Guid>(ce => ce.RowGUID);
            

            return new List<ITableDefinition>
            {
                ceTable    
            };
        }
    }
}
