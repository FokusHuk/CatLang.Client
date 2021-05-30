using System;

namespace Catlang.Client.Models
{
    public class StudiedWordDto
    {
		public StudiedWordDto(Guid userId, WordDto word, double riskFactor, int correctAnswers, int incorrectAnswers, DateTime lastAppearanceDate, WordStudyStatus status)
		{
			UserId = userId;
			Word = word ?? throw new ArgumentNullException(nameof(word));
			if (riskFactor < 0 || riskFactor > 100) throw new ArgumentOutOfRangeException(nameof(riskFactor));
			if (correctAnswers < 0) throw new ArgumentOutOfRangeException(nameof(correctAnswers));
			if (incorrectAnswers < 0) throw new ArgumentOutOfRangeException(nameof(incorrectAnswers));
			RiskFactor = riskFactor;
			CorrectAnswers = correctAnswers;
			IncorrectAnswers = incorrectAnswers;
			LastAppearanceDate = lastAppearanceDate;
			Status = status;
		}

		public Guid UserId { get; }
		public WordDto Word { get; }
		public double RiskFactor { get; set; }
		public int CorrectAnswers { get; set; }
		public int IncorrectAnswers { get; set; }
		public DateTime LastAppearanceDate { get; set; }
		public WordStudyStatus Status { get; set; }
	}
}
