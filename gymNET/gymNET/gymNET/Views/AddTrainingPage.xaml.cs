using System;
using Xamarin.Forms;

namespace gymNET
{
    public partial class AddTrainingPage : ContentPage
    {
        public AddTrainingPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var training = (Training)BindingContext;
            await App.DataManager.SaveTrainingAsync(training);
            await Navigation.PopAsync();
        }

        

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

