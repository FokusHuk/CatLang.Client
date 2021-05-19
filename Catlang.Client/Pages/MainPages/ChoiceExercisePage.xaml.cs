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

        public ChoiceExercisePage(Action openExerciseResultsPage)
        {
            InitializeComponent();

            OpenExerciseResultsPage = openExerciseResultsPage;
        }
    }
}
