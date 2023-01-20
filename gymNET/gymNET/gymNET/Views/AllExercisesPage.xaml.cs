using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gymNET
{
    public partial class AllExercisesPage : ContentPage
    {
        public AllExercisesPage()
        {
            InitializeComponent();
        }
        
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var training = (Training)BindingContext;

            listView.ItemsSource = await App.DataManager.GetExercisesAsync(training.Id);
        }

        async void OnAddExerciseClicked(object sender, EventArgs e)
        {
            var training = (Training)BindingContext;
            // add argument for TrainingPage(True)
            await Navigation.PushAsync(new AddExercisePage()
            {

                BindingContext = new Exercise
                {
                    Training_id = training.Id
                }
            });
        }

        async void OnSeriesSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AllSeriesPage
            {
                BindingContext = e.SelectedItem as Exercise
            });
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string input = button.CommandParameter.ToString();
            int id = Int32.Parse(input);
            await App.DataManager.DeleteExerciseAsync(id);
            await Navigation.PopAsync();
        }
    }
}



