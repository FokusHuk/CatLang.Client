namespace Catlang.Client.Models
{
    public class StudiedSetView
    {
        public StudiedSetView(string studyTopic, string authorName, string status, string attemptsCount, string correctAnswers)
        {
            StudyTopic = studyTopic;
            AuthorName = authorName;
            Status = status;
            AttemptsCount = attemptsCount;
            CorrectAnswers = correctAnswers;
        }

        public string StudyTopic { get; set; }
        public string AuthorName { get; set; }
        public string Status { get; set; }
        public string AttemptsCount { get; set; }
        public string CorrectAnswers { get; set; }
    }
}
