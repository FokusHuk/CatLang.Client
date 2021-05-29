using Catlang.Client.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для RecommendationPage.xaml
    /// </summary>
    public partial class RecommendationPage : Page
    {
        Action OpenExerciseCreationPage;
        private RecommendationPageView view;

        private const string HAVE_RECCOMENDATIONS_MESSAGE = "Ваши рекомендации с учетом последних изученных наборов";
        private const string WITHOUT_RECCOMENDATIONS_MESSAGE = "Для вас нет рекомендованных наборов";

        public RecommendationPage(Action openExerciseCreationPage)
        {
            InitializeComponent();

            OpenExerciseCreationPage = openExerciseCreationPage;

            UpdatePage();
        }

        private void RecommendedSetsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void LearnSet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StaticExerciseStorage.SetId = view.SelectedItem.Id;
            StaticExerciseStorage.SetName = view.SelectedItem.StudyTopic;
            OpenExerciseCreationPage();
        }

        private void UpdateSets_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void UpdatePage()
        {
            var recommendedSetsIds = CatLangRestClient.GetRecommendedSets();
            var recommendedSets = recommendedSetsIds
                .Select(s => CatLangRestClient.GetSetById(s))
                .ToList();
            var recommendedSetsModels = new ObservableCollection<SetModel>(recommendedSets.Select(s => new SetModel(s)).ToList());

            view = new RecommendationPageView(recommendedSetsModels);
            DataContext = view;

            if (recommendedSets.Count > 0)
                TitleMessage.Text = HAVE_RECCOMENDATIONS_MESSAGE;
            else
                TitleMessage.Text = WITHOUT_RECCOMENDATIONS_MESSAGE;

            LearnSet.IsEnabled = false;
        }
    }

    public class RecommendationPageView
    {
        public string UpdIconPath { get; set; }
        public SetModel SelectedItem { get; set; }
        public ObservableCollection<SetModel> RecommendedSets { get; set; }

        public RecommendationPageView(ObservableCollection<SetModel> recommendedSets)
        {
            UpdIconPath = Path.GetFullPath("Resources/update_icon.png");
            RecommendedSets = recommendedSets;
        }

        public RecommendationPageView(RecommendationPageView view)
        {
            SelectedItem = null;
            RecommendedSets = view.RecommendedSets;
            UpdIconPath = view.UpdIconPath;
        }
    }
}
