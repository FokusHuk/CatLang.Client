using Catlang.Client.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Catlang.Client.Pages.MainPages
{
    /// <summary>
    /// Логика взаимодействия для SetCreationPage.xaml
    /// </summary>
    public partial class SetCreationPage : Page
    {
        SetCreationPageView view;

        private const string SEARCH_FIELD_EMPTY_MESSAGE = "Введите слово для поиска";

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
                },
                new ObservableCollection<Word>()
                {
                    new Word(1, "Test1", "Translation"),
                    new Word(2, "Test2", "Translation"),
                    new Word(3, "Test3", "Translation"),
                    new Word(4, "Test4", "Translation"),
                    new Word(5, "Test5", "Translation"),
                    new Word(6, "Test6", "Translation"),
                    new Word(7, "Test7", "Translation")
                });
            DataContext = view;

            SearchField.Text = SEARCH_FIELD_EMPTY_MESSAGE;
            SearchField.Foreground = Brushes.Gray;

            CreateSet.IsEnabled = false;
        }

        private void RemoveWord_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var word = button.DataContext as Word;
            view.SetWords.Remove(word);
        }

        private void InsertWord_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var word = button.DataContext as Word;
            if (!view.SetWords.Contains(word))
                view.SetWords.Insert(0, word);
        }

        private void CreateSet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchField_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (SearchField.Text == SEARCH_FIELD_EMPTY_MESSAGE)
            {
                SearchField.Text = "";
                SearchField.Foreground = Brushes.Black;
            }           
        }

        private void SearchField_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SearchField.Text == "")
            {
                SearchField.Text = SEARCH_FIELD_EMPTY_MESSAGE;
                SearchField.Foreground = Brushes.Gray;
            }           
        }
    }

    public class SetCreationPageView
    {
        public Word SelectedItem { get; set; }
        public ObservableCollection<Word> SetWords { get; set; }
        public ObservableCollection<Word> Words { get; set; }

        public SetCreationPageView(ObservableCollection<Word> setWords, ObservableCollection<Word> words)
        {
            SetWords = setWords;
            Words = words;
        }

        public SetCreationPageView(SetCreationPageView view)
        {
            SelectedItem = null;
            SetWords = view.SetWords;
            Words = view.Words;
        }
    }
}
