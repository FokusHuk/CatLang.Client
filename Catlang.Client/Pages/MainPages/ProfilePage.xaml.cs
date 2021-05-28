using System;
using Catlang.Client.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        ProfilePageView view;
        List<StudiedWord> studiedWords;

        public ProfilePage()
        {
            InitializeComponent();

            var studiedSetDtos = CatLangRestClient.GetStudiedSets();
            var studiedsSetsInfo = studiedSetDtos
                .Select(s => CatLangRestClient.GetSetById(s.SetId))
                .ToList();
            var studiedSets = new ObservableCollection<StudiedSet>(
                studiedSetDtos
                    .Select(s => new StudiedSet(
                        studiedsSetsInfo.Single(i => i.Id == s.SetId).StudyTopic,
                        studiedsSetsInfo.Single(i => i.Id == s.SetId).AuthorName,
                        s.IsStudied ? "Изучено" : "Не изучено",
                        s.AttemptsCount.ToString(),
                        s.CorrectAnswers + " из " + s.AnswersCount))
                    .ToList());

            var studiedWordsDtos = CatLangRestClient.GetStudiedWords();

            studiedWords = studiedWordsDtos
                    .Select(w =>
                        new StudiedWord(
                            w.Word,
                            w.RiskFactor + "%",
                            w.CorrectAnswers,
                            w.IncorrectAnswers,
                            w.LastAppearanceDate.Date.ToShortDateString(),
                            GetWordsStudyStatus(w.Status)))
                    .OrderBy(w => w.Word.Original)
                    .ToList();

            var viewStudiedWords = new ObservableCollection<StudiedWord>(studiedWords);

            view = new ProfilePageView(studiedSets, viewStudiedWords, null);
            DataContext = view;
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
                view.UsedSets,
                new ObservableCollection<StudiedWord>(filteredStudiedWords),
                view.CreatedSets);
            DataContext = view;
        }
    }

    public class ProfilePageView
    {
        public ObservableCollection<StudiedSet> UsedSets { get; set; }
        public ObservableCollection<StudiedWord> StudiedWords { get; set; }
        public ObservableCollection<Set> CreatedSets { get; set; }

        public ProfilePageView(
            ObservableCollection<StudiedSet> usedSets,
            ObservableCollection<StudiedWord> studiedWords,
            ObservableCollection<Set> createdSets)
        {
            UsedSets = usedSets;
            StudiedWords = studiedWords;
            CreatedSets = createdSets;
        }

        public ProfilePageView(ProfilePageView view)
        {
            UsedSets = view.UsedSets;
            StudiedWords = view.StudiedWords;
            CreatedSets = view.CreatedSets;
        }
    }
}
