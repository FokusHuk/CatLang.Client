using Catlang.Client.Models;
using System;
using System.Collections.Generic;
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
        }

        private void SetsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var setWords = "";
            foreach (var word in view.SelectedItem.Words)
            {
                setWords += word.Original + " - " + word.Translation + "\n";
            }

            SetName.Text = view.SelectedItem.StudyTopic;
            SetWords.Text = setWords;
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
    }
}