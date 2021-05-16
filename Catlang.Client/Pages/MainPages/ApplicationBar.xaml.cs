using System.Windows.Controls;
using System;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationBar.xaml
    /// </summary>
    public partial class ApplicationBar : Page
    {
        private Action OpenSetsPage;
        private Action OpenRecommendationPage;
        private Action OpenProfilePage;

        public ApplicationBar(Action openSetsPage, Action openRecommendationPage, Action openProfilePage)
        {
            InitializeComponent();

            OpenSetsPage = openSetsPage;
            OpenRecommendationPage = openRecommendationPage;
            OpenProfilePage = openProfilePage;

            Username.Text = CatLangRestClient.Username;
        }

        private void Sets_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenSetsPage();
        }

        private void Recommendation_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenRecommendationPage();
        }

        private void Profile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenProfilePage();
        }
    }
}
