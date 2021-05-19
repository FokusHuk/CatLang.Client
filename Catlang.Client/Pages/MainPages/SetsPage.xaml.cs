using Catlang.Client.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для SetsPage.xaml
    /// </summary>
    public partial class SetsPage : Page
    {
        private SetsPageView view;

        public SetsPage()
        {
            InitializeComponent();

            var sets = CatLangRestClient.GetAllSets();
            var setModels = new ObservableCollection<SetModel>(sets.Select(s => new SetModel(s)).ToList());

            view = new SetsPageView(setModels);
            DataContext = view;

            LearnSet.IsEnabled = false;
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
                view.Sets = new ObservableCollection<SetModel>(
                    view.Sets.OrderByDescending(s => s.Efficiency));
                view = new SetsPageView(view);
                DataContext = view;
            }
            if (SortType.SelectedIndex == 1)
            {
                view.Sets = new ObservableCollection<SetModel>(
                    view.Sets.OrderByDescending(s => s.Popularity));
                view = new SetsPageView(view);
                DataContext = view;
            }
            if (SortType.SelectedIndex == 2)
            {
                view.Sets = new ObservableCollection<SetModel>(
                    view.Sets.OrderByDescending(s => s.Complexity));
                view = new SetsPageView(view);
                DataContext = view;
            }
            if (SortType.SelectedIndex == 3)
            {
                view.Sets = new ObservableCollection<SetModel>(
                    view.Sets.OrderByDescending(s => s.AverageStudyTime));
                view = new SetsPageView(view);
                DataContext = view;
            }
        }
    }

    public class SetsPageView
    {
        public SetModel SelectedItem { get; set; }
        public ObservableCollection<SetModel> Sets { get; set; }

        public SetsPageView(ObservableCollection<SetModel> sets)
        {
            Sets = sets;
        }

        public SetsPageView(SetsPageView view)
        {
            SelectedItem = null;
            Sets = view.Sets;
        }
    }
}