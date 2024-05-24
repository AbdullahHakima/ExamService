using ExamService.Data.Entities;
using ExamService.Data.Helpers.Enums;
using ExamService.Infrastructure.Interfaces;
using ExamService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExamService.Service.Services;

public class StudentQuizzesService : IStudentQuizzesService
{
    private readonly IStudentQuizzesRepository _studentQuizzesRepository;

    public StudentQuizzesService(IStudentQuizzesRepository studentQuizzesRepository)
    {
        _studentQuizzesRepository = studentQuizzesRepository;
    }

    public async Task AddStudentsToQuizAsync(List<StudentQuizzes> studentQuizzes)
    {
        await _studentQuizzesRepository.AddRangeAsync(studentQuizzes);
    }

    public async Task<StudentQuizzes?> GetStudentQuizAsync(Guid quizId, Guid studentId)
    {
        return _studentQuizzesRepository.GetTableNoTracking()
                                                  .Include(sq => sq.quiz)
                                                  .Include(sq => sq.submission)
                                                   .Include(sq => sq.Module)
                                                    .ThenInclude(sm => sm.ModuleQuestions)
                                                     .ThenInclude(mq => mq.Question)
                                                      .ThenInclude(q => q.Options)
                                                   .SingleOrDefault(sq => (sq.QuizId == quizId && sq.StudentId == studentId));
    }

    public async Task UpdateAttemptStatusAsync(Guid quizId, Guid studentId, QuizAttemptStatus status)
    {
        var studentQuiz = _studentQuizzesRepository.GetTableNoTracking().SingleOrDefault(sq => (sq.StudentId == studentId && sq.QuizId == quizId));
        studentQuiz.AttemptStatus = status;
        await _studentQuizzesRepository.UpdateAsync(studentQuiz);
    }

    public async Task UpdateStudentQuizAsync(StudentQuizzes studentQuizze)
    {
        await _studentQuizzesRepository.UpdateAsync(studentQuizze);
    }

    public async Task<StudentQuizzes?> ViewQuizDetailsAsync(Guid quizId, Guid studentId)
    {
        var inquiredQuiz = _studentQuizzesRepository.GetTableNoTracking()
                                                         .Include(sq => sq.submission)
                                                         .Include(sq => sq.Module)
                                                         .Include(sq => sq.quiz)
                                                            .ThenInclude(q => q.Instructor)//joined to get the quiz details and the student submission details
                                                         .SingleOrDefault(q => (q.QuizId == quizId && q.StudentId == studentId));
        return inquiredQuiz;
    }
}
