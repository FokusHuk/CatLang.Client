namespace Catlang.Client.Models
{
    public class ExerciseResultWord
    {
        public ExerciseResultWord(string taskWord, string chosenAnswer, string correctAnswer)
        {
            TaskWord = taskWord;
            ChosenAnswer = chosenAnswer;
            CorrectAnswer = correctAnswer;
        }

        public string TaskWord { get; }
        public string ChosenAnswer { get; }
        public string CorrectAnswer { get; }
    }
}
