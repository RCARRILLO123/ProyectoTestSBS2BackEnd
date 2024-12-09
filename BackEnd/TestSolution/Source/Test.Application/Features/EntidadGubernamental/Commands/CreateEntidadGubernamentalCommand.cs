using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Entidad;
using Test.Application.Interfaces.Repositories;
using Test.Application.Wrappers;

namespace Test.Application.Features.EntidadGubernamental.Commands
{
    public class CreateEntidadGubernamentalCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string? Descripcion { get; set; }
    }
    public class CreateEntidadGubernamentalCommandHandler : IRequestHandler<CreateEntidadGubernamentalCommand, Response<int>>
    {
        private readonly IEntidadGubernamentalRepositoryAsync _entidadGubernamentalRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateEntidadGubernamentalCommandHandler(IEntidadGubernamentalRepositoryAsync entidadGubernamentalRepositoryAsync, IMapper mapper)
        {
            _entidadGubernamentalRepositoryAsync = entidadGubernamentalRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEntidadGubernamentalCommand request, CancellationToken cancellationToken)
        {
            var girador = _mapper.Map<EntidadRequest>(request);
            var res = await _entidadGubernamentalRepositoryAsync.RegistrarEntidad(girador);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_HEAD);
        }
    }
}
