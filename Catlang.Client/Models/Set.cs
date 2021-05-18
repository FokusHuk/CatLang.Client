﻿using System;
using System.Collections.Generic;

namespace Catlang.Client.Models
{
    public class Set
    {
        public Set(Guid id, string authorName, string studyTopic, List<Word> words, int popularity, double efficiency, double averageStudyTime, double complexity)
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
        public List<Word> Words { get; set; }
        public int Popularity { get; set; }
        public double Efficiency { get; set; }
        public double AverageStudyTime { get; set; }
        public double Complexity { get; set; }
    }
}
