using ExamService.Core.Bases;
using ExamService.Core.Features.Quizzes.Queries.Responses;
using MediatR;

namespace ExamService.Core.Features.Quizzes.Queries.Models;

public class ViewQuizDetailsQueryModel : IRequest<Response<ViewQuizDetailsQueryResponse>>
{

    public Guid quizId { get; set; }
    public Guid studentId { get; set; }
}
