using LearningApp.DeviceSpecial;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Extension
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "LearningApp.Resources.UIPageResources";
        public string Text { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            var translated = GetResxNameByValue(Text);
           
            return translated;
        }
        private string GetResxNameByValue(string value)
        {
            ResourceManager resmgr = new ResourceManager(ResourceId
                               , typeof(TranslateExtension).GetTypeInfo().Assembly);

            CultureInfo ci = DependencyService.Get<ILocalization>().GetCurrentCulture();
            
            return resmgr.GetString(value, ci);
        }
    }
}
