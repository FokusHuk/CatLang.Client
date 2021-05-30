namespace Catlang.Client.Models
{
    public class UserStatisticsView
    {
        public UserStatisticsView(int createdSetsCount, double averageComplexity, int studiedWordsCount, int usedSetsCount, double averageAttemptsCount)
        {
            CreatedSetsCount = createdSetsCount;
            AverageComplexity = averageComplexity;
            StudiedWordsCount = studiedWordsCount;
            UsedSetsCount = usedSetsCount;
            AverageAttemptsCount = averageAttemptsCount;
        }

        public int CreatedSetsCount { get; set; }
        public double AverageComplexity { get; set; }
        public int StudiedWordsCount { get; set; }
        public int UsedSetsCount { get; set; }
        public double AverageAttemptsCount { get; set; }
    }
}
