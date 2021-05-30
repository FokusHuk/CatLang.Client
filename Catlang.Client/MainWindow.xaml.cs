using Catlang.Client.Pages;
using System.Windows;

namespace Catlang.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AuthenticationMain authentication;
        MainPage mainPage;

        public MainWindow()
        {
            InitializeComponent();
            CatLangRestClient.Initialize();

            authentication = new AuthenticationMain(() => Authenticate());
        }

        public void Authenticate()
        {
            mainPage = new MainPage();
            state.Content = mainPage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            state.Content = authentication;
        }
    }
}
