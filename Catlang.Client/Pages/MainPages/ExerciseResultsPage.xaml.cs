using Catlang.Client.Models;
using Catlang.Client.StaticStorages;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ExerciseResultsPage.xaml
    /// </summary>
    public partial class ChoiceExerciseResultsPage : Page
    {
        ExerciseResultsPageView view;

        public ChoiceExerciseResultsPage()
        {
            InitializeComponent();

            var exerciseResult = CatLangRestClient.FinishExercise(
                StaticExerciseStorage.ExerciseId, 
                StaticExerciseStorage.ExerciseFormat);

            CorrectAnswersStatistics.Text = exerciseResult.CorrectAnswers + " из " + exerciseResult.AnswersCount;

            if (exerciseResult.CorrectAnswers == exerciseResult.AnswersCount)
            {
                MistakesHeader.Visibility = System.Windows.Visibility.Hidden;
                MistakesTypes.Visibility = System.Windows.Visibility.Hidden;
                Mistakes.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                var mistakes = new ObservableCollection<ExerciseResultWord>(exerciseResult.WrongAnswers);
                view = new ExerciseResultsPageView(mistakes);
                DataContext = view;
            }
        }
    }
    public class ExerciseResultsPageView
    {
        public ObservableCollection<ExerciseResultWord> Mistakes { get; set; }

        public ExerciseResultsPageView(ObservableCollection<ExerciseResultWord> mistakes)
        {
            Mistakes = mistakes;
        }
    }
}
