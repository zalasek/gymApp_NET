using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gymNET
{
    public class DataManager
    {
        IRestService restService;

        public DataManager(IRestService service)
        {
            restService = service;
        }

        // trainings
        public Task<List<Training>> GetTrainingsAsync()
        {
            return restService.RefreshTrainingsAsync();
        }

        public Task SaveTrainingAsync(Training training)
        {
            return restService.SaveTrainingAsync(training);
        }

        public Task DeleteTrainingAsync(int id)
        {
            return restService.DeleteTrainingAsync(id);
        }

        // exercises
        public Task<List<Exercise>> GetExercisesAsync(int id)
        {
            return restService.RefreshExercisesAsync(id);
        }

        public Task SaveExerciseAsync(Exercise exercise)
        {
            return restService.SaveExerciseAsync(exercise);
        }

        public Task DeleteExerciseAsync(int id)
        {
            return restService.DeleteExerciseAsync(id);
        }

        // series
        public Task<List<Series>> GetSeriesAsync(int id)
        {
            return restService.RefreshSeriesAsync(id);
        }

        public Task SaveSeriesAsync(Series series)
        {
            return restService.SaveSeriesAsync(series);
        }

        public Task DeleteSeriesAsync(int id)
        {
            return restService.DeleteSeriesAsync(id);
        }


    }
}