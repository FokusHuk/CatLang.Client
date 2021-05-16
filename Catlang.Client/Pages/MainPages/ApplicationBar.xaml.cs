using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ApplicationBar.xaml
    /// </summary>
    public partial class ApplicationBar : Page
    {
        public ApplicationBar()
        {
            InitializeComponent();

            Username.Text = CatLangRestClient.Username;
        }
    }
}
