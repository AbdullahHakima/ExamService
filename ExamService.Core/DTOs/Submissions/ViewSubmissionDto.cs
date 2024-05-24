namespace ExamService.Core.DTOs.Submissions;

public class ViewSubmissionDto
{
    public DateTime SubmittedAt { get; set; }
    public decimal TotalGrade { get; set; }
    public TimeOnly TimeTaken { get; set; }

}
