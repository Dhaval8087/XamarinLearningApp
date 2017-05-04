using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningApp.Extension
{
   public class CountedLabel:Label, INotifyPropertyChanged
    {
        static readonly BindablePropertyKey WordCountKey = BindableProperty.CreateReadOnly("WordCount", typeof(int), typeof(CountedLabel), 0);

        public static BindableProperty WordCountProperty = WordCountKey.BindableProperty;


        public CountedLabel()
        {
            PropertyChanged += CountedLabel_PropertyChanged;
        }

        private void CountedLabel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName=="Text")
            {
                if(string.IsNullOrEmpty(Text))
                {
                    WordCount = 0;
                }
                else
                {
                    WordCount = Text.Split(' ', '-', '\u2014').Length;
                }
            }
        }

        public int WordCount
        {
            private set { SetValue(WordCountKey, value); }
            get { return (int)GetValue(WordCountProperty); }
        }

    }
    public interface INotifyPropertyChanged { event PropertyChangedEventHandler PropertyChanged; }
}
