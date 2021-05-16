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

        public Main()
        {
            InitializeComponent();

            applicationBar = new ApplicationBar(() => OpenSetsPage(), () => OpenRecommendationPage(), () => OpenProfilePage());
            setsPage = new SetsPage();
            recommendationPage = new RecommendationPage();
            profilePage = new ProfilePage();

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
    }
}
