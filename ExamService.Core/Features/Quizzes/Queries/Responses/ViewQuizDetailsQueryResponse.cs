using ExamService.Core.DTOs.Quizzes;
using ExamService.Core.DTOs.Submissions;

namespace ExamService.Core.Features.Quizzes.Queries.Responses;

public class ViewQuizDetailsQueryResponse
{
    public ViewQuizDetailsDto QuizDetails { get; set; }
    public ViewSubmissionDto? SubmissionDeatils { get; set; }
    public string status { get; set; }
    public bool IsEnrolled { get; set; }

}
