using System;
using Catlang.Client.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        ProfilePageView view;
        List<StudiedWordView> studiedWords;

        public ProfilePage()
        {
            InitializeComponent();
            UpdatePage();
        }

        private string GetWordsStudyStatus(WordStudyStatus status)
        {
            if (status == WordStudyStatus.Complete)
                return "Изучено";
            else if (status == WordStudyStatus.NeedPractice)
                return "В процессе";
            else
                return "Не изучено";
        }

        private void StudiedFilter_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterStudiedWords();
        }

        private void StudiedFilter_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterStudiedWords();
        }

        private void InProcessFilter_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterStudiedWords();
        }

        private void InProcessFilter_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterStudiedWords();
        }

        private void NotStudiedFilter_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterStudiedWords();
        }

        private void NotStudiedFilter_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            FilterStudiedWords();
        }

        private void FilterStudiedWords()
        {
            if (studiedWords == null || view == null || StudiedFilter == null || InProcessFilter == null || NotStudiedFilter == null) return;

            var filteredStudiedWords = studiedWords;

            if (!(bool)StudiedFilter.IsChecked)
            {
                filteredStudiedWords = filteredStudiedWords
                    .Where(w => w.Status != "Изучено")
                    .ToList();
            }
            if (!(bool)InProcessFilter.IsChecked)
            {
                filteredStudiedWords = filteredStudiedWords
                    .Where(w => w.Status != "В процессе")
                    .ToList();
            }
            if (!(bool)NotStudiedFilter.IsChecked)
            {
                filteredStudiedWords = filteredStudiedWords
                    .Where(w => w.Status != "Не изучено")
                    .ToList();
            }

            view = new ProfilePageView(
                view.Statistics,
                view.UsedSets,
                new ObservableCollection<StudiedWordView>(filteredStudiedWords),
                view.CreatedSets);
            DataContext = view;
        }

        private void UpdateSets_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdatePage();
        }

        private void UpdatePage()
        {
            var studiedSetDtos = CatLangRestClient.GetStudiedSets();
            var studiedsSetsInfo = studiedSetDtos
                .Select(s => CatLangRestClient.GetSetById(s.SetId))
                .ToList();
            var studiedSets = new ObservableCollection<StudiedSetView>(
                studiedSetDtos
                    .Select(s => new StudiedSetView(
                        studiedsSetsInfo.Single(i => i.Id == s.SetId).StudyTopic,
                        studiedsSetsInfo.Single(i => i.Id == s.SetId).AuthorName,
                        s.IsStudied ? "Изучено" : "Не изучено",
                        s.AttemptsCount.ToString(),
                        s.CorrectAnswers + " из " + s.AnswersCount))
                    .ToList());

            var studiedWordsDtos = CatLangRestClient.GetStudiedWords();

            studiedWords = studiedWordsDtos
                    .Select(w =>
                        new StudiedWordView(
                            w.Word,
                            w.RiskFactor + "%",
                            w.CorrectAnswers,
                            w.IncorrectAnswers,
                            w.LastAppearanceDate.Date.ToShortDateString(),
                            GetWordsStudyStatus(w.Status)))
                    .OrderBy(w => w.Word.Original)
                    .ToList();

            var viewStudiedWords = new ObservableCollection<StudiedWordView>(studiedWords);

            var createdSets = CatLangRestClient.GetCreatedSets();
            var createdSetsView = new ObservableCollection<CreatedSetDto>(createdSets);

            var averageComplexity = studiedsSetsInfo.Count == 0 ? 0 : Math.Round(studiedsSetsInfo.Sum(s => s.Complexity) / studiedsSetsInfo.Count, 2);
            var averageAttemptsCount = studiedSetDtos.Count == 0 ? 0 : Math.Round((double)studiedSetDtos.Sum(s => s.AttemptsCount) / studiedSetDtos.Count, 2);

            var statistics = new UserStatisticsView(
                createdSets.Count,
                averageComplexity,
                studiedWords.Count,
                studiedSets.Count,
                averageAttemptsCount);

            view = new ProfilePageView(statistics, studiedSets, viewStudiedWords, createdSetsView);
            DataContext = view;

            FilterStudiedWords();
        }
    }

    public class ProfilePageView
    {
        public string UpdIconPath { get; set; }
        public UserStatisticsView Statistics { get; set; }
        public ObservableCollection<StudiedSetView> UsedSets { get; set; }
        public ObservableCollection<StudiedWordView> StudiedWords { get; set; }
        public ObservableCollection<CreatedSetDto> CreatedSets { get; set; }

        public ProfilePageView(
            UserStatisticsView userStatistics,
            ObservableCollection<StudiedSetView> usedSets,
            ObservableCollection<StudiedWordView> studiedWords,
            ObservableCollection<CreatedSetDto> createdSets)
        {
            Statistics = userStatistics;
            UsedSets = usedSets;
            StudiedWords = studiedWords;
            CreatedSets = createdSets;
            UpdIconPath = Path.GetFullPath("Resources/update_icon.png");
        }

        public ProfilePageView(ProfilePageView view)
        {
            Statistics = view.Statistics;
            UsedSets = view.UsedSets;
            StudiedWords = view.StudiedWords;
            CreatedSets = view.CreatedSets;
            UpdIconPath = view.UpdIconPath;
        }
    }
}
