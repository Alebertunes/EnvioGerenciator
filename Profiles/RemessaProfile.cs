using AutoMapper;
using EnviGerenciator.Dto;
using EnviGerenciator.Model;

namespace EnviGerenciator.Profiles;

public class RemessaProfile : Profile
{
    public RemessaProfile()
    {
        CreateMap<CreateRemessaDto, Remessa>();
        CreateMap<Remessa, CreateRemessaDto>();
        CreateMap<ReadRemessaDto, Remessa>();
        CreateMap<Remessa, ReadRemessaDto>();
    }
}