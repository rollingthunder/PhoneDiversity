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
using System.Windows.Data;
using DiversityPhone.ViewModels;

namespace DiversityPhone.View
{
    public class MapManagementPivotConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!((value is MapManagementVM.Pivot) && targetType == typeof(int)))
                throw new NotSupportedException();


            var v = (MapManagementVM.Pivot)value;
            switch (v)
            {
                case MapManagementVM.Pivot.Local:
                    return 0;
                case MapManagementVM.Pivot.Online:
                    return 1;
                default:
                    System.Diagnostics.Debugger.Break();
                    return 0;                    
            }

            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!((value is int) && targetType == typeof(MapManagementVM.Pivot)))
                throw new NotSupportedException();


            var v = (int)value;
            switch (v)
            {
                case 0:
                    return MapManagementVM.Pivot.Local;
                case 1:
                    return MapManagementVM.Pivot.Online;             
                default:                    
                    return MapManagementVM.Pivot.Local;                    
            }  
        }
    }
}
