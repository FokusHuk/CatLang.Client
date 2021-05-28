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

            var studiedWords = new ObservableCollection<StudiedWord>()
            {
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete),
                new StudiedWord(Guid.NewGuid(), new Word(0, "Original", "Перевод"),
                12.5, 1, 5, DateTime.Now, WordStudyStatus.Complete)
            };

            view = new ProfilePageView(studiedSets, studiedWords);
            DataContext = view;
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
