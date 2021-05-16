using Catlang.Client.Pages;
using System.Windows;

namespace Catlang.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string serverUrl = "http://localhost:5000";
        public static string token = "";

        AuthenticationMain authentication;
        Main mainPage;

        public MainWindow()
        {
            InitializeComponent();
            CatLangRestClient.Initialize(serverUrl);

            authentication = new AuthenticationMain(() => Authenticate());
            mainPage = new Main();
        }

        public void Authenticate()
        {
            state.Content = mainPage;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            state.Content = authentication;
        }
    }
}
