﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindableProp : ContentPage
    {
        public BindableProp()
        {
            InitializeComponent();
            int wordCount = countedLabel.WordCount;
            wordCountLabel.Text = wordCount + " words";
        }
    }
}
