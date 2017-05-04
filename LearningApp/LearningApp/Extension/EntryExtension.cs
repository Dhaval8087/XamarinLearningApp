using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningApp.Extension
{
    public class EntryExtension
    {

        public static bool GetAllowOnlyString(BindableObject obj)
        {
            return (bool)obj.GetValue(AllowOnlyStringProperty);
        }
        public static void SetAllowOnlyString(BindableObject obj, bool value)
        {
            obj.SetValue(AllowOnlyStringProperty, value);
        }
       
        public static readonly BindableProperty AllowOnlyStringProperty =
        BindableProperty.CreateAttached("AllowOnlyString", typeof(bool), typeof(EntryExtension), defaultValue: false,propertyChanged: AllowOnlyString);
        private static void AllowOnlyString(BindableObject d,object oldvalue,object newvalue)
        {
            if (d is Entry)
            {
                Entry txtObj = (Entry)d;
                txtObj.TextChanged += (s, arg) =>
                {
                    Entry txt = s as Entry;
                    if (!Regex.IsMatch(txt.Text, "^[a-zA-Z]*$"))
                    {
                        txtObj.BackgroundColor = Color.Red;
                        
                    }
                    else
                    {
                        txtObj.BackgroundColor = Color.Transparent;
                    }
                };
            }
        }

    }
}
