using Catlang.Client.Pages.Authentication;
using System;
using System.Windows.Controls;

namespace Catlang.Client.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class AuthenticationMain : Page
    {
        AuthorizationPanel authorizationPanel;
        RegistrationPanel registrationPanel;

        public AuthenticationMain(Action setMainPage)
        {
            InitializeComponent();
            authorizationPanel = new AuthorizationPanel(setMainPage);
            registrationPanel = new RegistrationPanel(setMainPage);
            authPanel.Content = authorizationPanel;
        }

        private void authPanelName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (authPanelName.SelectedIndex == 0)
                authPanel.Content = authorizationPanel;
            else
                authPanel.Content = registrationPanel;

        }
    }
}
