using Catlang.Client.Models;
using Catlang.Client.StaticStorages;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для SetsPage.xaml
    /// </summary>
    public partial class SetsPage : Page
    {
        Action OpenExerciseCreationPage;
        Action OpenSetCreationPage;
        private SetsPageView view;

        public SetsPage(Action openExerciseCreationPage, Action openSetCreationPage)
        {
            InitializeComponent();

            OpenExerciseCreationPage = openExerciseCreationPage;
            OpenSetCreationPage = openSetCreationPage;

            UpdatePage();
        }

        private void SetsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (view.SelectedItem == null)
            {
                SetName.Text = "";
                SetWords.Text = "";
                LearnSet.IsEnabled = false;
                return;
            }

            var setWords = "";
            foreach (var word in view.SelectedItem.Words)
            {
                setWords += word.Original + " - " + word.Translation + "\n";
            }

            SetName.Text = view.SelectedItem.StudyTopic;
            SetWords.Text = setWords;

            LearnSet.IsEnabled = true;
        }

        private void SortType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortType.SelectedIndex == 0)
            {
                view.Sets = new ObservableCollection<SetView>(
                    view.Sets.OrderByDescending(s => s.Efficiency));
                view = new SetsPageView(view);
                DataContext = view;
            }
            if (SortType.SelectedIndex == 1)
            {
                view.Sets = new ObservableCollection<SetView>(
                    view.Sets.OrderByDescending(s => s.Popularity));
                view = new SetsPageView(view);
                DataContext = view;
            }
            if (SortType.SelectedIndex == 2)
            {
                view.Sets = new ObservableCollection<SetView>(
                    view.Sets.OrderByDescending(s => s.Complexity));
                view = new SetsPageView(view);
                DataContext = view;
            }
            if (SortType.SelectedIndex == 3)
            {
                view.Sets = new ObservableCollection<SetView>(
                    view.Sets.OrderByDescending(s => s.AverageStudyTime));
                view = new SetsPageView(view);
                DataContext = view;
            }
        }

        private void UpdateSets_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void LearnSet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StaticExerciseStorage.SetId = view.SelectedItem.Id;
            StaticExerciseStorage.SetName = view.SelectedItem.StudyTopic;
            OpenExerciseCreationPage();
        }

        private void UpdatePage()
        {
            var sets = CatLangRestClient.GetAllSets();
            var setModels = new ObservableCollection<SetView>(sets.Select(s => new SetView(s)).ToList());

            view = new SetsPageView(setModels);
            DataContext = view;

            LearnSet.IsEnabled = false;
        }

        private void CreateSet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenSetCreationPage();
        }
    }

    public class SetsPageView
    {
        public string UpdIconPath { get; set; }
        public SetView SelectedItem { get; set; }
        public ObservableCollection<SetView> Sets { get; set; }

        public SetsPageView(ObservableCollection<SetView> sets)
        {
            UpdIconPath = Path.GetFullPath("Resources/update_icon.png");
            Sets = sets;
        }

        public SetsPageView(SetsPageView view)
        {
            SelectedItem = null;
            Sets = view.Sets;
            UpdIconPath = view.UpdIconPath;
        }
    }
}