using AutoMapper;
using EnviGerenciator.Dto;
using EnviGerenciator.Model;

namespace EnviGerenciator.Profiles;

public class FilialProfile : Profile
{
    public FilialProfile()
    {
        CreateMap<CreateFilialDto, Filial>();
        CreateMap<Filial, CreateFilialDto>();
        CreateMap<ReadFilialDto, Filial>();
        CreateMap<Filial, ReadFilialDto>();
    }
}