﻿using System.Collections.Generic;

namespace Catlang.Client.Models
{
    public class ExerciseResult
    {
        public ExerciseResult(int correctAnswers, int answersCount, List<ExerciseResultWord> wrongAnswers)
        {
            CorrectAnswers = correctAnswers;
            AnswersCount = answersCount;
            WrongAnswers = wrongAnswers;
        }

        public int CorrectAnswers { get; set; }
        public int AnswersCount { get; set; }
        public List<ExerciseResultWord> WrongAnswers { get; set; }
    }
}