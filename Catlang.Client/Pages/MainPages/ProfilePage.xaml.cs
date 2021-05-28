using System;
using Catlang.Client.Models;
using System.Collections.ObjectModel;
using System.Linq;
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
            var studiedWords = new ObservableCollection<StudiedWord>(
                studiedWordsDtos
                    .Select(w =>
                        new StudiedWord(
                            w.Word,
                            w.RiskFactor + "%",
                            w.CorrectAnswers,
                            w.IncorrectAnswers,
                            w.LastAppearanceDate.Date.ToShortDateString(),
                            GetWordsStudyStatus(w.Status)))
                    .OrderBy(w => w.Word.Original)
                    .ToList());

            view = new ProfilePageView(studiedSets, studiedWords);
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
    }

    public class ProfilePageView
    {
        public ObservableCollection<StudiedSet> UsedSets { get; set; }
        public ObservableCollection<StudiedWord> StudiedWords { get; set; }

        public ProfilePageView(
            ObservableCollection<StudiedSet> usedSets,
            ObservableCollection<StudiedWord> studiedWords)
        {
            UsedSets = usedSets;
            StudiedWords = studiedWords;
        }
    }
}
