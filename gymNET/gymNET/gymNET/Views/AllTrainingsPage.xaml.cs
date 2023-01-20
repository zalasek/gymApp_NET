using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gymNET
{
    public partial class AllTrainingsPage : ContentPage
    {
        public AllTrainingsPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.DataManager.GetTrainingsAsync();
        }

        async void OnAddTrainingClicked(object sender, EventArgs e)
        {
            // add argument for TrainingPage(True)
            await Navigation.PushAsync(new AddTrainingPage()
            {
                BindingContext = new Training
                {
                    //Description = "test description"
                }
            });
        }

        async void OnTrainingSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AllExercisesPage
            {
                BindingContext = e.SelectedItem as Training
            });
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string input = button.CommandParameter.ToString();
            int id = Int32.Parse(input);
            await App.DataManager.DeleteTrainingAsync(id);
            //await Navigation.PopAsync();
            await Navigation.PushAsync(new AllTrainingsPage()
            {
            });
        }
    }
}



