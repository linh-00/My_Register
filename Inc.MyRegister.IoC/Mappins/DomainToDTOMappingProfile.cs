using AutoMapper;
using Inc.MyRegister.Application.DTOs;
using Inc.MyRegister.Domain.Entities;

namespace Inc.MyRegister.IoC.Mappins
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Empresas, EmpresaDTO>().ReverseMap();


        }
    }
}
