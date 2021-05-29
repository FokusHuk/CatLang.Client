using Catlang.Client.Models;
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
    /// Логика взаимодействия для SetCreationPage.xaml
    /// </summary>
    public partial class SetCreationPage : Page
    {
        SetCreationPageView view;

        public SetCreationPage()
        {
            InitializeComponent();

            view = new SetCreationPageView(
                new ObservableCollection<Word>()
                {
                    new Word(1, "Word1", "Translation"),
                    new Word(2, "Word2", "Translation"),
                    new Word(3, "Word3", "Translation"),
                    new Word(4, "Word4", "Translation"),
                    new Word(5, "Word5", "Translation"),
                    new Word(6, "Word6", "Translation"),
                    new Word(7, "Word7", "Translation")
                });
            DataContext = view;
        }

        private void RemoveWord_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var word = button.DataContext as Word;
            view.SetWords.Remove(word);
        }

        private void CreateSet_Click(object sender, RoutedEventArgs e)
        {

        }
    }

    public class SetCreationPageView
    {
        public Word SelectedItem { get; set; }
        public ObservableCollection<Word> SetWords { get; set; }

        public SetCreationPageView(ObservableCollection<Word> setWords)
        {
            SetWords = setWords;
        }

        public SetCreationPageView(SetCreationPageView view)
        {
            SelectedItem = null;
            SetWords = view.SetWords;
        }
    }
}
