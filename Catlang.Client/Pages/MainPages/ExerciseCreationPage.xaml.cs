using Catlang.Client.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ExerciseCreationPage.xaml
    /// </summary>
    public partial class ExerciseCreationPage : Page
    {
        Action OpenConformityExercisePage;
        Action OpenChoiceExercisePage;

        public ExerciseCreationPage(Action openConformityExercisePage, Action openChoiceExercisePage)
        {
            InitializeComponent();

            OpenConformityExercisePage = openConformityExercisePage;
            OpenChoiceExercisePage = openChoiceExercisePage;
        }

        private void Conformity_Click(object sender, RoutedEventArgs e)
        {
            OpenConformityExercisePage();
        }

        private void Choice_Click(object sender, RoutedEventArgs e)
        {
            OpenChoiceExercisePage();
        }

        private void SetExerciseFormat()
        {
            if (ExerciseType.SelectedIndex == 0)
                StaticExerciseStorage.ExerciseFormat = ExerciseFormat.EnRu;
            else
                StaticExerciseStorage.ExerciseFormat = ExerciseFormat.RuEn;
        }
    }
}
