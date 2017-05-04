using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using LearningApp.Uitility;
namespace LearningApp.Extension
{
    public class ListPicker : Picker
    {
        public ListPicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        public static BindableProperty ConverterProperty =
               BindableProperty.Create<ListPicker, IValueConverter>(o => o.Converter, default(IValueConverter), BindingMode.TwoWay, null,
                null, null, null);

        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<ListPicker, IEnumerable>(o => o.ItemsSource, default(IEnumerable), BindingMode.OneWay, null,
            new BindableProperty.BindingPropertyChangedDelegate<IEnumerable>(OnItemsSourceChanged), null, null);

        public static BindableProperty SelectedItemProperty =
                BindableProperty.Create<ListPicker, object>(o => o.SelectedItem, default(object), BindingMode.TwoWay, null,
                 new BindableProperty.BindingPropertyChangedDelegate<object>(OnSelectedItemChanged), null, null);


        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set
            {
                SetValue(ConverterProperty, value);
            }
        }


        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
        {
            try
            {
                var picker = bindable as ListPicker;
                picker.Items.Clear();
                if (newvalue != null)
                {
                    foreach (var item in newvalue)
                    {
                        picker.Items.Add(picker.Convert(item, picker.Converter));
                    }
                }
            }
            catch
            { //To solve navigation issues}
            }
        }


    private String Convert(object input, IValueConverter converter)
        {
            return converter == null ? input.ToString() : (String)converter.Convert(input, typeof(String), null, System.Globalization.CultureInfo.CurrentUICulture);
        }

        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = ItemsSource[SelectedIndex];
            }
        }
        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as ListPicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.ItemsSource.IndexOf(newvalue);
            }

        }
    }
    public class BindablePicker : Picker
    {
        #region const
        public BindablePicker()
        {
            this.SelectedIndexChanged += OnSelectedIndexChanged;
        }
        #endregion
        #region Fields

        //Bindable property for the items source
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindablePicker, IEnumerable>(p => p.ItemsSource, null, propertyChanged: OnItemsSourcePropertyChanged);

        //Bindable property for the selected item
        public static BindableProperty SelectedItemProperty =
                BindableProperty.Create<ListPicker, object>(o => o.SelectedItem, default(object), BindingMode.TwoWay, null,
                 new BindableProperty.BindingPropertyChangedDelegate<object>(OnSelectedItemChanged), null, null);

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        /// <value>
        /// The items source.
        /// </value>
        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when [items source property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="value">The value.</param>
        /// <param name="newValue">The new value.</param>
        private static void OnItemsSourcePropertyChanged(BindableObject bindable, IEnumerable value, IEnumerable newValue)
        {
            var picker = (BindablePicker)bindable;
            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                notifyCollection.CollectionChanged += (sender, args) =>
                {
                    if (args.NewItems != null)
                    {
                        foreach (var newItem in args.NewItems)
                        {
                            picker.Items.Add((newItem ?? "").ToString());
                        }
                    }
                    if (args.OldItems != null)
                    {
                        foreach (var oldItem in args.OldItems)
                        {
                            picker.Items.Remove((oldItem ?? "").ToString());
                        }
                    }
                };
            }

            if (newValue == null)
                return;

            picker.Items.Clear();

            foreach (var item in newValue)
                picker.Items.Add((item ?? "").ToString());
        }

        /// <summary>
        /// Called when [selected item property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="value">The value.</param>
        /// <param name="newValue">The new value.</param>
        private static void OnSelectedItemPropertyChanged(BindableObject bindable, object value, object newValue)
        {
            var picker = (BindablePicker)bindable;
            if (picker.ItemsSource != null)
                picker.SelectedIndex = picker.ItemsSource.IndexOf(picker.SelectedItem);
        }
        private static void OnSelectedItemChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var picker = bindable as BindablePicker;
            if (newvalue != null)
            {
                picker.SelectedIndex = picker.ItemsSource.IndexOf(newvalue);
            }

        }
        private void OnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            if (SelectedIndex < 0 || SelectedIndex > Items.Count - 1)
            {
                SelectedItem = null;
            }
            else
            {
                SelectedItem = ItemsSource[SelectedIndex];
            }
        }
        #endregion
    }
}
