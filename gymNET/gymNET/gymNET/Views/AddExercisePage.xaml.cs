using System;
using Xamarin.Forms;

namespace gymNET
{
    public partial class AddExercisePage : ContentPage
    {
        public AddExercisePage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var exercise = (Exercise)BindingContext;
            await App.DataManager.SaveExerciseAsync(exercise);
            await Navigation.PopAsync();
        }


        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

