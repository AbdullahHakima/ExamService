using ExamService.Core.DTOs.Submissions;
using ExamService.Data.Entities;

namespace ExamService.Core.Mapping.SubmissionsMapping;

public partial class SubmissionProfile
{
    public void ViewSubmissionDetailsMapping()
    {
        CreateMap<Submission, ViewSubmissionDto>()
            .ForMember(dest => dest.SubmittedAt, opt => opt.MapFrom(src => src.SubmitAt))
            .ForMember(dest => dest.TotalGrade, opt => opt.MapFrom(src => src.TotalGrade))
            .ForMember(dest => dest.TimeTaken, opt => opt.MapFrom(src => src.TimeTaken));
    }
}
