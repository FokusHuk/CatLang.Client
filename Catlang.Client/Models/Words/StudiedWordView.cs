using System;

namespace Catlang.Client.Models
{
    public class StudiedWordView
    {
        public StudiedWordView(
            WordDto word,
            string riskFactor,
            int correctAnswers,
            int incorrectAnswers,
            string lastAppearanceDate,
            string status)
        {
            Word = word;
            RiskFactor = riskFactor;
            CorrectAnswers = correctAnswers;
            IncorrectAnswers = incorrectAnswers;
            LastAppearanceDate = lastAppearanceDate;
            Status = status;
        }

        public WordDto Word { get; }
		public string RiskFactor { get; set; }
		public int CorrectAnswers { get; set; }
		public int IncorrectAnswers { get; set; }
		public string LastAppearanceDate { get; set; }
		public string Status { get; set; }
	}
}
