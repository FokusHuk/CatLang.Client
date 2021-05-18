using System;
using System.Collections.Generic;

namespace Catlang.Client.Models
{
    public class SetModel
    {
        public SetModel(Guid id, string authorName, string studyTopic, string wordsLine, int popularity, double efficiency, double averageStudyTime, double complexity)
        {
            Id = id;
            AuthorName = authorName;
            StudyTopic = studyTopic;
            WordsLine = wordsLine;
            Popularity = popularity;
            Efficiency = efficiency;
            AverageStudyTime = averageStudyTime;
            Complexity = complexity;
        }

        public SetModel(Set set)
        {
            Id = set.Id;
            AuthorName = set.AuthorName;
            StudyTopic = set.StudyTopic;
            Words = set.Words;
            Popularity = set.Popularity;
            Efficiency = set.Efficiency;
            AverageStudyTime = set.AverageStudyTime;
            Complexity = set.Complexity;

            WordsLine = "";
            foreach (var word in Words)
            {
                WordsLine += word.Original + ", ";
            }
            WordsLine = WordsLine.Remove(WordsLine.Length - 2);
        }

        public Guid Id { get; set; }
        public string AuthorName { get; set; }
        public string StudyTopic { get; set; }
        public string WordsLine { get; set; }
        public List<Word> Words { get; set; }
        public int Popularity { get; set; }
        public double Efficiency { get; set; }
        public double AverageStudyTime { get; set; }
        public double Complexity { get; set; }
    }
}
