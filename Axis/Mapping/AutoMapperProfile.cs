using Axis.DataTransferObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace Axis.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Project mappings
            CreateMap<Project, ProjectDTO>();
            CreateMap<CreateProjectDTO, Project>()
                .ForMember(dest => dest.LastEditDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastEditMSID, opt => opt.MapFrom(src => "SYSTEM"));
            CreateMap<UpdateProjectDTO, Project>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // YLine mappings
            CreateMap<YLine, YLineDTO>();
            CreateMap<CreateYLineDTO, YLine>();

            // Competitor mappings
            CreateMap<Competitor, CompetitorDTO>();
            CreateMap<CreateCompetitorDTO, Competitor>();

            // ProjectNote mappings
            CreateMap<ProjectNote, ProjectNoteDTO>();
            CreateMap<CreateProjectNoteDTO, ProjectNote>()
                .ForMember(dest => dest.LoadDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.EditDate, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.LastEditMSID, opt => opt.MapFrom(src => src.OriginalMSID));
        }
    }
}
