using System.Collections.Generic;

namespace Catlang.Client.Models
{
    public class ExerciseResultDto
    {
        public ExerciseResultDto(int correctAnswers, int answersCount, List<ExerciseResultWordDto> wrongAnswers)
        {
            CorrectAnswers = correctAnswers;
            AnswersCount = answersCount;
            WrongAnswers = wrongAnswers;
        }

        public int CorrectAnswers { get; set; }
        public int AnswersCount { get; set; }
        public List<ExerciseResultWordDto> WrongAnswers { get; set; }
    }
}
