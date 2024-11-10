using AutoMapper;
using Challenge.DTO;
using Challenge.Models;

namespace Challenge.Mapping
{
    public class MappingConfiguration: Profile
    {
        public MappingConfiguration()
        {
            CreateMap<ArchivoMedicoCreateDTO, TArchivoMedico>()
                    .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FechaInicio.Value)));
            CreateMap<ArchivoMedicoDeleteDTO, TArchivoMedico>()
                    .ForMember(dest => dest.FechaFin, opt => opt.MapFrom(src => DateOnly.FromDateTime(src.FechaFin.Value)));
            CreateMap<ArchivoMedicoUpdateDTO, TArchivoMedico>();
        }
    }
}
