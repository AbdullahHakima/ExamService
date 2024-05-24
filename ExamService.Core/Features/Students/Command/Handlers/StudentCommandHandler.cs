using AutoMapper;
using ExamService.Core.Bases;
using ExamService.Core.Features.Modules.Queries.Responses;
using ExamService.Core.Features.Students.Command.Models;
using ExamService.Data.Entities;
using ExamService.Data.Helpers.Enums;
using ExamService.Service.Interfaces;
using MediatR;

namespace ExamService.Core.Features.Students.Command.Handlers;

public class StudentCommandHandler : ResponseHandler
                                  , IRequestHandler<EnrollToQuizCommandModel, Response<GetModuleByIdQueryResponse>>
                                  , IRequestHandler<SubmitQuizAnswersCommandModel, Response<string>>
{
    private readonly IStudentQuizzesService _studentQuizzesService;
    private readonly IMapper _mapper;
    private readonly IModuleService _moduleService;
    private readonly IQuizService _quizService;
    private readonly ISubmissionService _submissionService;

    public StudentCommandHandler(ISubmissionService submissionService, IQuizService quizService, IStudentQuizzesService studentQuizzesService, IMapper mapper, IModuleService moduleService)
    {
        _studentQuizzesService = studentQuizzesService;
        _mapper = mapper;
        _moduleService = moduleService;
        _quizService = quizService;
        _submissionService = submissionService;
    }

    public async Task<Response<GetModuleByIdQueryResponse>> Handle(EnrollToQuizCommandModel request, CancellationToken cancellationToken)
    {
        var inquiredModule = await _moduleService.GetStudentModuleByQuizId(request.quizId, request.studentId);
        if (inquiredModule == null)
            return NotFound<GetModuleByIdQueryResponse>("Not Found module associated to you");
        var moduleMapped = _mapper.Map<GetModuleByIdQueryResponse>(inquiredModule);
        return Success(moduleMapped);
    }

    public async Task<Response<string>> Handle(SubmitQuizAnswersCommandModel request, CancellationToken cancellationToken)
    {
        var studentQuiz = await _studentQuizzesService.GetStudentQuizAsync(request.quizId, request.studentId);

        decimal proportionalFactor = (studentQuiz.quiz.Grade * request.TotalGrade);

        var moduleGrade = studentQuiz.Module.TotalGrade;

        request.TotalGrade = proportionalFactor / moduleGrade;

        var submission = _mapper.Map<Submission>(request);


        var result = await _submissionService.AddSubmission(submission);
        if (result != null)
        {

            if (submission.SubmitAt > studentQuiz.quiz.ClosedAt)
                studentQuiz.AttemptStatus = QuizAttemptStatus.Late;
            else
                studentQuiz.AttemptStatus = QuizAttemptStatus.Submitted;

            studentQuiz.SubmissionId = result.Id;
            await _studentQuizzesService.UpdateStudentQuizAsync(studentQuiz);
            return Success("Submission successful.");
        }
        else
        {
            return BadRequest("Unable to process your request.");
        }
    }
}
