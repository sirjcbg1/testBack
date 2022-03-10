using Application.DTOs;
using Application.Features.Ingreso.Commands.Create;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappins
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs
            CreateMap<Ingreso, IngresoDto>();    
            #endregion

            #region Commands
            CreateMap<CreateIngresoCommand, Ingreso>();
            #endregion
        }
    }
}
