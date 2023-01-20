using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using gymNET;
using Xamarin.Essentials;

namespace gymNET
{
    public class RestService : IRestService
    {
        HttpClient client;
        JsonSerializerOptions serializerOptions;

        public List<Training> Trainings { get; private set; }
        public List<Exercise> Exercises { get; private set; }
        public List<Series> Series { get; private set; }

        public RestService()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // trainings
        public async Task<List<Training>> RefreshTrainingsAsync()
        {
            Trainings = new List<Training>();

            Uri uri = new Uri(string.Format(Constants.AllTrainingsUrl, string.Empty));
            
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Trainings = JsonSerializer.Deserialize<List<Training>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Trainings;
        }

        public async Task SaveTrainingAsync(Training training)
        {
            Uri uri = new Uri(string.Format(Constants.AllTrainingsUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Training>(training, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTraining successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteTrainingAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.TrainingUrl, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTraining successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        // EXERCISES

        public async Task<List<Exercise>> RefreshExercisesAsync(int id)
        {
            Exercises = new List<Exercise>();

            Uri uri = new Uri(string.Format(Constants.ExercisesInTrainingUrl, id));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Exercises = JsonSerializer.Deserialize<List<Exercise>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Exercises;
        }

        public async Task SaveExerciseAsync(Exercise exercise)
        {
            Uri uri = new Uri(string.Format(Constants.AllExercisesUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Exercise>(exercise, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Exercise successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteExerciseAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.ExerciseUrl, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Exercise successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        // SERIES
        public async Task<List<Series>> RefreshSeriesAsync(int id)
        {
            Series = new List<Series>();

            Uri uri = new Uri(string.Format(Constants.SeriesInExerciseUrl, id));

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Series = JsonSerializer.Deserialize<List<Series>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Series;
        }

        public async Task SaveSeriesAsync(Series series)
        {
            Uri uri = new Uri(string.Format(Constants.AllSeriesUrl, string.Empty));

            try
            {
                string json = JsonSerializer.Serialize<Series>(series, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Series successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteSeriesAsync(int id)
        {
            Uri uri = new Uri(string.Format(Constants.SeriesUrl, id));

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\Series successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}