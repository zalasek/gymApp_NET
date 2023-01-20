using System.Collections.Generic;
using System.Threading.Tasks;
using gymNET;

namespace gymNET
{
    public interface IRestService
    {
        // trainings
        Task<List<Training>> RefreshTrainingsAsync();

        Task SaveTrainingAsync(Training training);

        Task DeleteTrainingAsync(int id);

        //exercises
        Task<List<Exercise>> RefreshExercisesAsync(int id);

        Task SaveExerciseAsync(Exercise exercise);

        Task DeleteExerciseAsync(int id);

        //series
        Task<List<Series>> RefreshSeriesAsync(int id);

        Task SaveSeriesAsync(Series series);

        Task DeleteSeriesAsync(int id);



    }
}