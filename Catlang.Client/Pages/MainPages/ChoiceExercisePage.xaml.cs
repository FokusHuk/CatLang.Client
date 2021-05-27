using Catlang.Client.Models;
using System;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ChoiceExercisePage.xaml
    /// </summary>
    public partial class ChoiceExercisePage : Page
    {
        private Action OpenExerciseResultsPage;
        private ChoiceExercise exercise;
        private int currentTask;
        private int tasksCount;

        private string WordsCountValue() => (currentTask + 1) + " / " + tasksCount;

        public ChoiceExercisePage(Action openExerciseResultsPage)
        {
            InitializeComponent();

            OpenExerciseResultsPage = openExerciseResultsPage;

            exercise = CatLangRestClient.StartChoiceExercise(
                StaticExerciseStorage.ExerciseFormat,
                StaticExerciseStorage.SetId);
            currentTask = -1;
            tasksCount = exercise.Tasks.Count;

            StaticExerciseStorage.ExerciseId = exercise.Id;

            SetName.Text = StaticExerciseStorage.SetName;
            UpdateTask();
        }

        private void FirstAnswer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckAndCommit(exercise.Tasks[currentTask].AnswerWords[0]);
        }

        private void SecondAnswer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckAndCommit(exercise.Tasks[currentTask].AnswerWords[1]);
        }

        private void ThirdAnswer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckAndCommit(exercise.Tasks[currentTask].AnswerWords[2]);
        }

        private void FourthAnswer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckAndCommit(exercise.Tasks[currentTask].AnswerWords[3]);
        }

        private void CheckAndCommit(string answer)
        {
            CommitAnswer(answer);

            if (currentTask == tasksCount - 1)
            {
                OpenExerciseResultsPage();
                return;
            }

            UpdateTask();
        }

        private void CommitAnswer(string answer)
        {
            CatLangRestClient.CommitChoiceAnswer(
                StaticExerciseStorage.ExerciseFormat,
                exercise.Id,
                exercise.SetId,
                exercise.Tasks[currentTask].TaskWordId,
                answer);
        }

        private void UpdateTask()
        {
            currentTask++;
            WordsCount.Text = WordsCountValue();
            TaskWord.Text = exercise.Tasks[currentTask].TaskWord;
            FirstAnswer.Content = exercise.Tasks[currentTask].AnswerWords[0];
            SecondAnswer.Content = exercise.Tasks[currentTask].AnswerWords[1];
            ThirdAnswer.Content = exercise.Tasks[currentTask].AnswerWords[2];
            FourthAnswer.Content = exercise.Tasks[currentTask].AnswerWords[3];
        }
    }
}
