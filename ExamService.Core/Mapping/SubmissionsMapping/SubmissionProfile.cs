using AutoMapper;

namespace ExamService.Core.Mapping.SubmissionsMapping;

public partial class SubmissionProfile : Profile
{
    public SubmissionProfile()
    {
        ViewSubmissionDetailsMapping();
    }
}
