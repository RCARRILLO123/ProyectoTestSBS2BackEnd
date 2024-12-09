using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Entidad;
using Test.Application.Features.EntidadGubernamental.Commands;

namespace Test.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateEntidadGubernamentalCommand, EntidadRequest>();
            CreateMap<UpdateEntidadGubernamentalCommand, EntidadRequest>();
            
        }
    }
}
