using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для SetsPage.xaml
    /// </summary>
    public partial class SetsPage : Page
    {

        public SetsPage()
        {
            InitializeComponent();

            DataContext = new View();
        }
    }

    public class View
    {
        public ObservableCollection<Set> Sets { get; set; }

        public View()
        {
            Sets = new ObservableCollection<Set>()
            {
                new Set(Guid.NewGuid(), "Ghoul", "Memories", "love, dead, robots, inside...", 12, 5, 1, 993),
                new Set(Guid.NewGuid(), "Admin", "Simple", "true, false, mthfckr...", 1, 1, 1, 1)
            };
        }
    }

    public class Set
    {
        public Set(Guid id, string authorName, string studyTopic, string words, int popularity, double efficiency, double averageStudyTime, double complexity)
        {
            Id = id;
            AuthorName = authorName;
            StudyTopic = studyTopic;
            Words = words;
            Popularity = popularity;
            Efficiency = efficiency;
            AverageStudyTime = averageStudyTime;
            Complexity = complexity;
        }

        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string StudyTopic { get; set; }
        public string Words { get; set; }
        public int Popularity { get; set; }
        public double Efficiency { get; set; }
        public double AverageStudyTime { get; set; }
        public double Complexity { get; set; }
    }

    public class Word
    {
        public Word(int id, string original, string translation)
        {
            Id = id;
            Original = original;
            Translation = translation;
        }

        public int Id { get; }

        public string Original { get; set; }

        public string Translation { get; set; }
    }
}