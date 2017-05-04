using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using LearningApp.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyAppListViewNonSelectableRenderer), typeof(MyAppListViewNonSelectableRenderer))]
namespace LearningApp.Droid
{
    public class MyAppListViewNonSelectableRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if(e.OldElement !=null)
            {

            }
            if(e.NewElement!=null)
            {
                Control.ItemSelected += Control_ItemSelected; ;
            }
        }

        private void Control_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            e.View.Selected = false;
        }
    }
}