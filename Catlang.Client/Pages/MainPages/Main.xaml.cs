using Catlang.Client.Pages.MainPages;
using System.Windows.Controls;

namespace Catlang.Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        ApplicationBar applicationBar;
        SetsPage setsPage;
        RecommendationPage recommendationPage;
        ProfilePage profilePage;
        ExerciseCreationPage exerciseCreationPage;

        public Main()
        {
            InitializeComponent();

            applicationBar = new ApplicationBar(() => OpenSetsPage(), () => OpenRecommendationPage(), () => OpenProfilePage());
            setsPage = new SetsPage(() => OpenExerciseCreationPage());
            recommendationPage = new RecommendationPage(() => OpenExerciseCreationPage());
            profilePage = new ProfilePage();
            exerciseCreationPage = new ExerciseCreationPage(() => OpenConformityExercisePage(), () => OpenChoiceExercisePage());

            appBar.Content = applicationBar;
            body.Content = setsPage;
        }

        private void OpenSetsPage()
        {
            body.Content = setsPage;
        }

        private void OpenRecommendationPage()
        {
            body.Content = recommendationPage;
        }

        private void OpenProfilePage()
        {
            body.Content = profilePage;
        }

        private void OpenExerciseCreationPage()
        {
            body.Content = exerciseCreationPage;
        }

        private void OpenConformityExercisePage()
        {
            body.Content = new ConformityExercisePage(() => OpenConformityExercuseResultsPage());
        }

        private void OpenChoiceExercisePage()
        {
            body.Content = new ChoiceExercisePage(() => OpenChoiceExerciseResultsPage());
        }

        private void OpenChoiceExerciseResultsPage()
        {
            body.Content = new ChoiceExerciseResultsPage();
        }

        private void OpenConformityExercuseResultsPage()
        {
            body.Content = new ConformityExerciseResultsPage();
        }
    }
}
