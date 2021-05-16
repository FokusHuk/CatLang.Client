using System;
using System.Windows;
using System.Windows.Controls;

namespace Catlang.Client.Pages.Authentication
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPanel.xaml
    /// </summary>
    public partial class AuthorizationPanel : Page
    {
        private Action SetMainPage;

        public AuthorizationPanel(Action setMainPage)
        {
            InitializeComponent();

            SetMainPage = setMainPage;
            Login.Text = "admin";
            Password.Password = "159321";
        }

        private void Authorize_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password.Password;
            var result = CatLangRestClient.Authorize(login, password);
            if (result)
                SetMainPage();
        }
    }
}
