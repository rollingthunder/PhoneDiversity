﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using DiversityPhone.Model;
using DiversityPhone.ViewModels;

namespace DiversityPhone.View
{
    public partial class ViewMap : PhoneApplicationPage
    {

        private ViewMapVM VM { get { return this.DataContext as ViewMapVM; } }
        private const double SCALEMIN = 0.2;
        private const double SCALEMAX = 3;
        


        public ViewMap()
        {
            InitializeComponent();
        }

        private void focusOn(double x, double y)
        {
            scrollViewer.ScrollToHorizontalOffset(x);
            scrollViewer.ScrollToVerticalOffset(y);
        }


        private void OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
        {
            VM.Zoom = transform.ScaleX;
        }

        private void OnPinchDelta(object sender, PinchGestureEventArgs e)
        {
            double scale = VM.Zoom * Math.Sqrt(e.DistanceRatio);
            if (scale < SCALEMIN)
                scale = SCALEMIN;
            if (scale > SCALEMAX)
                scale = SCALEMAX;
            VM.Zoom = scale;
            transform.ScaleX = scale;
            transform.ScaleY = scale;
            VM.calculatePixelPointForActual();
            VM.calculatePixelPointForItem();
            MainCanvas.Height = VM.BaseHeight * VM.Zoom;
            MainCanvas.Width  = VM.BaseWidth * VM.Zoom;
        }

        private void OnPinchCompleted(object sender, PinchGestureEventArgs e)
        {
           
        }


        private void scrollViewer_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (VM != null && VM.ItemPosPoint != null)
                if(VM.ActualPosPoint.X>0 && VM.ActualPosPoint.Y>0)
                     focusOn(VM.ActualPosPoint.X-scrollViewer.Width/2, VM.ActualPosPoint.Y-scrollViewer.Height/2);
        }

        private void scrollViewer_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if(VM!= null && VM.ItemPosPoint!=null)
                if (VM.ItemPosPoint.X > 0 && VM.ItemPosPoint.Y > 0)
                    focusOn(VM.ItemPosPoint.X-scrollViewer.Width/2, VM.ItemPosPoint.Y-scrollViewer.Height/2);
        }
    }
}