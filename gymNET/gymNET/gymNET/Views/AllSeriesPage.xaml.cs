using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gymNET
{
    public partial class AllSeriesPage : ContentPage
    {
        public AllSeriesPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var exercise = (Exercise)BindingContext;
            Console.WriteLine("exercise.Id");
            Console.WriteLine(exercise.Id);

            listView.ItemsSource = await App.DataManager.GetSeriesAsync(exercise.Id);
        }

        async void OnAddSeriesClicked(object sender, EventArgs e)
        {
            var exercise = (Exercise)BindingContext;
            // add argument for TrainingPage(True)
            await Navigation.PushAsync(new AddSeriesPage()
            {

                BindingContext = new Series
                {
                    Exercise_id = exercise.Id
                }
            });
        }
/*
        async void OnSeriesSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new AllExercisesPage
            {
                BindingContext = e.SelectedItem as Exercise
            });
        }
*/
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string input = button.CommandParameter.ToString();
            int id = Int32.Parse(input);
            await App.DataManager.DeleteSeriesAsync(id);
            await Navigation.PopAsync();
        }
    }
}

