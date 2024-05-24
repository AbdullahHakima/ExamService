using ExamService.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExamService.Core.Features.Students.Command.Models;

public class SubmitQuizAnswersCommandModel : IRequest<Response<string>>
{
    [FromBody]
    public Guid quizId { get; set; }
    [FromBody]
    public Guid moduleId { get; set; }
    [FromBody]
    public Guid studentId { get; set; }

    public decimal TotalGrade { get; set; }
    public TimeOnly TimeTaken { get; set; }
}
