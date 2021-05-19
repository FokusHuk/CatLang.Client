namespace Catlang.Client.Models
{
    public class ConformityExerciseTask
    {
        public ConformityExerciseTask(int taskWordId, string taskWord, string answerWord)
        {
            TaskWordId = taskWordId;
            TaskWord = taskWord;
            AnswerWord = answerWord;
        }

        public int TaskWordId { get; }
        public string TaskWord { get; }
        public string AnswerWord { get; }
    }
}
