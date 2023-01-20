using System;
using Xamarin.Forms;

namespace gymNET
{
    public partial class AddSeriesPage : ContentPage
    {
        public AddSeriesPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var series = (Series)BindingContext;
            await App.DataManager.SaveSeriesAsync(series);
            await Navigation.PopAsync();
        }


        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

