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

        public Main()
        {
            InitializeComponent();

            applicationBar = new ApplicationBar();
            appBar.Content = applicationBar;
        }
    }
}
