using AutoMapper;
using domain;
using application.models;

namespace application.automapper;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<Cliente, ClienteModel>();
        CreateMap<ClienteModel, Cliente>();
    }    
}
