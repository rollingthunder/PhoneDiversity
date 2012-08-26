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
using System.Windows.Data;
using System.Reactive.Disposables;

namespace DiversityPhone.View
{
    public partial class InfoLabel : UserControl
    {
        public InfoLabel()
        {
            InitializeComponent();

            var b = new Binding("Text")
            {
                Source = this,
                Mode = BindingMode.OneWay                
            };
            textField.SetBinding(TextBlock.TextProperty,b);


        }



        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(InfoLabel), new PropertyMetadata("Command not available"));
    }
}
