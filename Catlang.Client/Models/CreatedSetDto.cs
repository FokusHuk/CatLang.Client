namespace Catlang.Client.Models
{
    public class CreatedSetDto
    {
        public CreatedSetDto(string studyTopic, double complexity, double efficiency, int popularity, double averageStudyTime)
        {
            StudyTopic = studyTopic;
            Complexity = complexity;
            Efficiency = efficiency;
            Popularity = popularity;
            AverageStudyTime = averageStudyTime;
        }

        public string StudyTopic { get; set; }
        public double Complexity { get; set; }
        public double Efficiency { get; set; }
        public int Popularity { get; set; }
        public double AverageStudyTime { get; set; }
    }
}
