using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningApp.Model
{
    public class Fruit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageSource img { get; set; }
        public int Price { get; set; }
    }
}
