﻿namespace Catlang.Client.Models
{
    public class ExerciseResultWord
    {
        public ExerciseResultWord(string taskWord, string chosenAnswer, string correctAnswer)
        {
            TaskWord = taskWord;
            ChosenAnswer = chosenAnswer;
            CorrectAnswer = correctAnswer;
        }

        public string TaskWord { get; set; }
        public string ChosenAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
