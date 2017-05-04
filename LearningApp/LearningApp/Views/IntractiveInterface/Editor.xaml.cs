using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.IntractiveInterface
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editor : ContentPage
    {
        public Editor()
        {
            InitializeComponent();
            editor.Text = "This is the Test Editor, you can test search funcationlity using this editor you have to just enter the word you want to find out";
        }
        void OnEditorFocused(object sender, FocusEventArgs args)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 0.5));
            }
        }
        void OnEditorUnfocused(object sender, FocusEventArgs args)
        {
            if (Device.OS == TargetPlatform.iOS)
            {
                AbsoluteLayout.SetLayoutBounds(editor, new Rectangle(0, 0, 1, 1));
            }
        }

        private void search_SearchButtonPressed(object sender, EventArgs e)
        {
            ApplyCss();
           
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyCss();
        }
        private void ApplyCss()
        {
            if(editor.Text !=null && search.Text!=null)
            {
                if (editor.Text.ToLower().Contains(search.Text.ToLower()) && search.Text.Length > 0)
                {
                    editor.BackgroundColor = Color.Yellow;
                }
                else
                {
                    editor.BackgroundColor = Color.Transparent;
                }
            }
            else
            {
                editor.BackgroundColor = Color.Transparent;
            }
           
        }
    }
}
