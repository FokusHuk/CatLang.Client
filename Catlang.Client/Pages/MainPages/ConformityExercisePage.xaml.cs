using Catlang.Client.Models;
using System.Windows;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ConformityExercisePage.xaml
    /// </summary>
    public partial class ConformityExercisePage : Page
    {
        private ConformityExercise exercise;
        private int currentTask;
        private int tasksCount;

        private string WordsCountValue() => (currentTask + 1) + " / " + tasksCount;

        public ConformityExercisePage()
        {
            InitializeComponent();

            exercise = CatLangRestClient.StartConformityExercise(
                StaticExerciseStorage.ExerciseFormat,
                StaticExerciseStorage.SetId);
            currentTask = -1;
            tasksCount = exercise.Tasks.Count;
       
            SetName.Text = StaticExerciseStorage.SetName;
            UpdateTask();
        }

        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            CommitAnswer(true);
            UpdateTask();
        }

        private void Incorrect_Click(object sender, RoutedEventArgs e)
        {
            CommitAnswer(false);
            UpdateTask();
        }

        private void CommitAnswer(bool answer)
        {
            CatLangRestClient.CommitConformityAnswer(
                StaticExerciseStorage.ExerciseFormat,
                exercise.Id,
                exercise.SetId,
                exercise.Tasks[currentTask].TaskWordId,
                exercise.Tasks[currentTask].AnswerWord,
                answer);
        }

        private void UpdateTask()
        {
            currentTask++;
            WordsCount.Text = WordsCountValue();
            Original.Text = exercise.Tasks[currentTask].TaskWord;
            Translation.Text = exercise.Tasks[currentTask].AnswerWord;
        }
    }
}
