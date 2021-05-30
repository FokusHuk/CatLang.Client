using Catlang.Client.Models;
using Catlang.Client.StaticStorages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private char[] RuAlphabet = Enumerable.Range('а', 'я' - 'а' + 1).Select(c => (char)c).ToArray();
        private char[] EnAlphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();
        
        public SetCreationPage()
        {
            InitializeComponent();

            if (!StaticWordsStorage.DoesWordsLoaded)
            {
                StaticWordsStorage.Words = CatLangRestClient.GetAllWords();
            }

            view = new SetCreationPageView(
                new ObservableCollection<Word>(),
                new ObservableCollection<Word>());
            DataContext = view;

            SearchField.Text = SEARCH_FIELD_EMPTY_MESSAGE;
            SearchField.Foreground = Brushes.Gray;
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
            if (!view.SetWords.Contains(word) && view.SetWords.Count < 20)
                view.SetWords.Insert(0, word);
        }

        private void CreateSet_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateSetName() && view.SetWords.Count >= 10)
            {
                var studyTopic = SetName.Text;
                var setWordsIds = view.SetWords.Select(w => w.Id).ToArray();

                CatLangRestClient.CreateSet(studyTopic, setWordsIds);

                SetName.Text = "";
                ClearSetWordsList();
                SearchField.Text = SEARCH_FIELD_EMPTY_MESSAGE;
                SearchField.Foreground = Brushes.Gray;
            }
            else
            {
                MessageBox.Show("Название набора должно содержать больше 3 символов.\nНабор должен содержать минимум 10 слов.", "Ошибка при создании набора", MessageBoxButton.OK);
            }
        }

        private bool ValidateSetName()
        {
            var setName = SetName.Text;

            if (setName.Length > 3)
            {
                for (int i = 0; i < setName.Length; i++)
                    if (!char.IsLetter(setName[i]))
                        return false;

                SetName.Text = GetStringFromCharArray(SetName.Text.Select(s => SetName.Text.IndexOf(s) == 0 ? char.ToUpper(s) : char.ToLower(s)).ToArray());
                return true;

            }

            return false;
        }

        private string GetStringFromCharArray(char[] array)
        {
            string ret = "";

            foreach (var c in array)
                ret += c;

            return ret;
        }

        private void SearchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            ClearWordsList();

            if (SearchField.Text.Length > 1)
            {
                ClearWordsList();

                var length = SearchField.Text.Length;

                var filteredWords = new List<Word>();

                if (EnAlphabet.Contains(SearchField.Text[0]))
                    filteredWords = StaticWordsStorage.Words
                        .Where(w => w.Original.Length >= length && w.Original.ToLower().Substring(0, length) == SearchField.Text.ToLower())
                        .ToList();
                else
                    filteredWords = StaticWordsStorage.Words
                        .Where(w => w.Translation.Length >= length && w.Translation.ToLower().Substring(0, length) == SearchField.Text.ToLower())
                        .ToList();

                foreach (var word in filteredWords)
                    view.Words.Insert(view.Words.Count, word);
            }
        }

        private void ClearWordsList()
        {
            for (int i = view.Words.Count - 1; i >= 0; i --)
                view.Words.RemoveAt(i);
        }

        private void ClearSetWordsList()
        {
            for (int i = view.SetWords.Count - 1; i >= 0; i--)
                view.SetWords.RemoveAt(i);
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

        private void SetName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SetName.Text.Length > 25)
            {
                SetName.Text = SetName.Text.Substring(0, 25);
                SetName.CaretIndex = 25;
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
