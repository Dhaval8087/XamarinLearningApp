using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LearningApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningApp.ViewModels
{
    public class ScrollingStackViewModel:ViewModelBase
    {
       

        public ScrollingStackViewModel()
        {
            Random rnd = new Random();
            List<int> unique = new List<int>();
            int loopcount = 0;
            Device.OnPlatform(iOS: () => { loopcount = 20; }, Android: () => { loopcount = 5; });
            for (int i = 0; i < loopcount; i++)
            {
                int random = 0;
                if (unique.Count==0)
                {
                    random= rnd.Next(1, 4);
                   
                }
                else
                {
                    var generateNew = rnd.Next(1, 4);
                    if (unique.Contains(generateNew))
                        random = rnd.Next(1, 4);
                    else
                        random = generateNew;
                    
                }
                unique.Add(random);

                var Price = rnd.Next(10, 50);
                string Name = string.Empty;
                string ImgName = string.Empty;
                string Description = string.Empty;
                switch (random)
                {
                    case 1:
                        Name = "Capsicum";
                        ImgName = "Images/one.png";
                        Description = "Capsicum is a genus of flowering plants in the nightshade family Solanaceae";
                        break;
                    case 2:
                        Name = "Mirch";
                        ImgName = "Images/two.png";
                        Description = "International dishes are served at this lively diner venue reveling in the culture of the USA";
                        break;
                    case 3:
                        Name = "Tomato";
                        ImgName = "Images/three.png";
                        Description = "The chili pepper is the fruit of plants from the genus Capsicum";
                        break;
                    default:
                        break;
                }
                Fruits.Add(new Fruit()
                {
                    Name = Name,
                    img = ImageSource.FromFile(ImgName),
                    Description=Description,
                    Price= Price

                });
                if (i % 3 == 0)
                    unique = new List<int>();
            }
        }
        private INavigation _Navigation;

        public INavigation Navigation
        {
            get { return _Navigation; }
            set { _Navigation = value; }
        }
       


        private ObservableCollection<Fruit> _Fruits=new ObservableCollection<Fruit>();

        public ObservableCollection<Fruit> Fruits
        {
            get { return _Fruits; }
            set { _Fruits = value; RaisePropertyChanged("Fruits"); }
        }


    }
}
