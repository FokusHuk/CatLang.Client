using Catlang.Client.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Catlang.Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для ConformityExerciseResult.xaml
    /// </summary>
    public partial class ConformityExerciseResultsPage : Page
    {
        ConformityExerciseResultPageView view;

        public ConformityExerciseResultsPage()
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
                var conformityExerciseResultWords = GetConformityExerciseResultWords(exerciseResult.WrongAnswers);
                var mistakes = new ObservableCollection<ConformityExerciseResultWord>(conformityExerciseResultWords);
                view = new ConformityExerciseResultPageView(mistakes);
                DataContext = view;
            }
        }

        private List<ConformityExerciseResultWord> GetConformityExerciseResultWords(List<ExerciseResultWord> words)
        {
            return words.Select(w => new ConformityExerciseResultWord(
                w.TaskWord,
                w.ChosenAnswer,
                w.ChosenAnswer == w.CorrectAnswer ? "Неверно" : "Верно",
                w.CorrectAnswer))
                .ToList();
        }
    }

    public class ConformityExerciseResultPageView
    {
        public ObservableCollection<ConformityExerciseResultWord> Mistakes { get; set; }

        public ConformityExerciseResultPageView(ObservableCollection<ConformityExerciseResultWord> mistakes)
        {
            Mistakes = mistakes;
        }
    }

    public class ConformityExerciseResultWord
    {
        public ConformityExerciseResultWord(string taskWord, string taskAnswer, string userAnswer, string correctAnswer)
        {
            TaskWord = taskWord;
            TaskAnswer = taskAnswer;
            UserAnswer = userAnswer;
            CorrectAnswer = correctAnswer;
        }

        public string TaskWord { get; set; }
        public string TaskAnswer { get; set; }
        public string UserAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
