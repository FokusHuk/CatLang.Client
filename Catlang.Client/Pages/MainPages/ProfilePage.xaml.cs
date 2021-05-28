using Catlang.Client.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        ProfilePageView view;

        public ProfilePage()
        {
            InitializeComponent();

            view = new ProfilePageView(new ObservableCollection<StudiedSet>()
            {
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12"),
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12"),
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12"),
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12"),
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12"),
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12"),
                new StudiedSet("Topic", "Name", "Изучено", "10", "10 из 12")
            });

            DataContext = view;
        }


    }

    public class ProfilePageView
    {
        public ObservableCollection<StudiedSet> UsedSets { get; set; }

        public ProfilePageView(ObservableCollection<StudiedSet> usedSets)
        {
            UsedSets = usedSets;
        }
    }
}
