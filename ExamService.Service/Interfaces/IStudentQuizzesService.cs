using ExamService.Data.Entities;
using ExamService.Data.Helpers.Enums;

namespace ExamService.Service.Interfaces;

public interface IStudentQuizzesService
{
    Task UpdateAttemptStatusAsync(Guid quizId, Guid studentId, QuizAttemptStatus status);
    Task<StudentQuizzes> ViewQuizDetailsAsync(Guid quizId, Guid studentId);
    Task AddStudentsToQuizAsync(List<StudentQuizzes> studentQuizzes);
    Task<StudentQuizzes> GetStudentQuizAsync(Guid quizId, Guid studentId);
    Task UpdateStudentQuizAsync(StudentQuizzes studentQuizze);
}
