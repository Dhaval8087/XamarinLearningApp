﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace LearningApp.UserControls
{
    public partial class CustomeEntry : Grid
    {
        public CustomeEntry()
        {
            InitializeComponent();
            entry.Text = string.Empty;
            entry.TextChanged += Entry_TextChanged;
            cancelbtn.Command = new Command(() =>
            {
                entry.Text = string.Empty;
            });

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            Text = entry.Text;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CustomeEntry), default(string));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string PlaceHolder
        {
            get { return entry.Placeholder; }
            set { entry.Placeholder = value; }
        }

    }
}
