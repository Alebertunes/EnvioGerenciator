using AutoMapper;
using EnviGerenciator.Dto;
using EnviGerenciator.Model;

namespace EnviGerenciator.Profiles;

public class ObjetoProfile : Profile
{
    public ObjetoProfile()
    {
        CreateMap<CreateObjetoDto, Objeto>();
        CreateMap<Objeto, CreateObjetoDto>();
        CreateMap<ReadObjetoDto, Objeto>();
    }
}