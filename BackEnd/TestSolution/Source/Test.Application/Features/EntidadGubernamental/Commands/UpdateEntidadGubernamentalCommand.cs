using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Entidad;
using Test.Application.Features.EntidadGubernamental.Commands;
using Test.Application.Interfaces.Repositories;
using Test.Application.Wrappers;

namespace Test.Application.Features.EntidadGubernamental.Commands
{
    public class UpdateEntidadGubernamentalCommand : IRequest<Response<int>>
    {
        public int? Id { get; set; }
        public string? Descripcion { get; set; }
    }
    public class UpdateEntidadGubernamentalCommandHandler : IRequestHandler<UpdateEntidadGubernamentalCommand, Response<int>>
    {
        private readonly IEntidadGubernamentalRepositoryAsync _entidadGubernamentalRepositoryAsync;
        private readonly IMapper _mapper;

        public UpdateEntidadGubernamentalCommandHandler(IEntidadGubernamentalRepositoryAsync entidadGubernamentalRepositoryAsync, IMapper mapper)
        {
            _entidadGubernamentalRepositoryAsync = entidadGubernamentalRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateEntidadGubernamentalCommand request, CancellationToken cancellationToken)
        {
            var girador = _mapper.Map<EntidadRequest>(request);
            var res = await _entidadGubernamentalRepositoryAsync.ActualizarEntidad(girador);
            return new Response<int>(res, Constantes.SUCCEDED_UPDATE);
        }
    }
}
