

using Xamarin.Essentials;
using Xamarin.Forms;

namespace gymNET
{
    public static class Constants
    {
        // URL of REST service
        //public static string RestUrl = "https://YOURPROJECT.azurewebsites.net:8081/api/todoitems/{0}";

        // URL of REST service (Android does not use localhost)
        // Use http cleartext for local deployment. Change to https for production
        //public static string AllTrainingsUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/all_trainings" : "http://localhost:5000/all_trainings";
        public static string AllTrainingsUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/all_trainings" : "http://10.0.2.2:5000/all_trainings";
        public static string TrainingUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/training/{0}" : "http://localhost:5000/training/{0}";

        public static string ExercisesInTrainingUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/exercises_in_training/{0}" : "http://10.0.2.2:5000/exercises_in_training/{0}";
        public static string AllExercisesUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/all_exercises" : "http://10.0.2.2:5000/all_exercises";
        public static string ExerciseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/exercise/{0}" : "http://10.0.2.2:5000/exercise/{0}";

        public static string SeriesInExerciseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/series_in_exercise/{0}" : "http://10.0.2.2:5000/series_in_exercise/{0}";
        public static string AllSeriesUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/all_series" : "http://10.0.2.2:5000/all_series";
        public static string SeriesUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/series/{0}" : "http://10.0.2.2:5000/series/{0}";


    }
}
