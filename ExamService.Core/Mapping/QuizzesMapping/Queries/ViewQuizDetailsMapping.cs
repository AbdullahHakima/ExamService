using ExamService.Core.DTOs.Quizzes;
using ExamService.Data.Entities;

namespace ExamService.Core.Mapping.QuizzesMapping;

public partial class QuizProfile
{
    public void ViewQuizDetailsMapping()
    {
        CreateMap<Quiz, ViewQuizDetailsDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.InstructorName, opt => opt.MapFrom(src => src.Instructor.DisplayName))
            .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.TotalGrade, opt => opt.MapFrom(src => src.Grade))
            .ForMember(dest => dest.ClosedAt, opt => opt.MapFrom(src => src.ClosedAt.ToLocalTime()))
            .ForMember(dest => dest.StartedDate, opt => opt.MapFrom(src => src.StartedDate.ToLocalTime()));
    }
}
