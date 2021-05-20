using Catlang.Client.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ConformityExercisePage.xaml
    /// </summary>
    public partial class ConformityExercisePage : Page
    {
        private Action OpenExerciseResultsPage;
        private ConformityExercise exercise;
        private int currentTask;
        private int tasksCount;

        private string WordsCountValue() => (currentTask + 1) + " / " + tasksCount;

        public ConformityExercisePage(Action openExerciseResultsPage)
        {
            InitializeComponent();

            OpenExerciseResultsPage = openExerciseResultsPage;

            exercise = CatLangRestClient.StartConformityExercise(
                StaticExerciseStorage.ExerciseFormat,
                StaticExerciseStorage.SetId);
            currentTask = -1;
            tasksCount = exercise.Tasks.Count;

            StaticExerciseStorage.ExerciseId = exercise.Id;
       
            SetName.Text = StaticExerciseStorage.SetName;
            UpdateTask();
        }

        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            CommitAnswer(true);

            if (currentTask == tasksCount - 1)
            {
                OpenExerciseResultsPage();
                return;
            }

            UpdateTask();
        }

        private void Incorrect_Click(object sender, RoutedEventArgs e)
        {
            CommitAnswer(false);

            if (currentTask == tasksCount - 1)
            {
                OpenExerciseResultsPage();
                return;
            }

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
