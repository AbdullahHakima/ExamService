namespace ExamService.Core.DTOs.Quizzes;

public class ViewQuizDetailsDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartedDate { get; set; }
    public DateTime ClosedAt { get; set; }
    public string InstructorName { get; set; }
    public decimal TotalDuration { get; set; }
    public decimal TotalGrade { get; set; }

}
