using ExamService.Core.Features.Quizzes.Queries.Responses;
using ExamService.Data.Entities;

namespace ExamService.Core.Mapping.QuizzesMapping;
public partial class QuizProfile
{
    public void ViewQuizDetailsQueryMapping()
    {
        CreateMap<StudentQuizzes, ViewQuizDetailsQueryResponse>()
            .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.AttemptStatus.ToString()))
            .ForMember(dest => dest.IsEnrolled, opt => opt.MapFrom(src => src.Enrolled))
            .ForMember(dest => dest.QuizDetails, opt => opt.MapFrom(src => src.quiz))
            .ForMember(dest => dest.SubmissionDeatils, opt => opt.MapFrom(src => src.submission));
    }

}

