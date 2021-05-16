using System;
using System.Windows;
using System.Windows.Controls;

namespace Catlang.Client.Pages.Authentication
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPanel.xaml
    /// </summary>
    public partial class RegistrationPanel : Page
    {
        private Action SetMainPage;

        public RegistrationPanel(Action setMainPage)
        {
            InitializeComponent();

            SetMainPage = setMainPage;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var username = Username.Text;
            var login = Login.Text;
            var password = Password.Password;
            var result = CatLangRestClient.CreateUser(username, login, password);
            if (result)
            {
                var authResult = CatLangRestClient.Authorize(login, password);
                if (authResult)
                    SetMainPage();
            }
        }
    }
}
