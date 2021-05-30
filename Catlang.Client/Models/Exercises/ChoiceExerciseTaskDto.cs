namespace Catlang.Client.Models
{
    public class ChoiceExerciseTaskDto
    {
        public ChoiceExerciseTaskDto(int taskWordId, string taskWord, string[] answerWords)
        {
            TaskWordId = taskWordId;
            TaskWord = taskWord;
            AnswerWords = answerWords;
        }

        public int TaskWordId { get; }
        public string TaskWord { get; }
        public string[] AnswerWords { get; }
    }
}
