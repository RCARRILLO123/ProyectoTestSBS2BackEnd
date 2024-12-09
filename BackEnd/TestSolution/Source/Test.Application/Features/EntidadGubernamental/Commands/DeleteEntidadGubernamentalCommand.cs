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
    public class DeleteEntidadGubernamentalCommand : IRequest<Response<int>>
    {
        public int CodigoEntidad { get; set; }
    }
    public class DeleteEntidadGubernamentalCommandHandler : IRequestHandler<DeleteEntidadGubernamentalCommand, Response<int>>
    {
        private readonly IEntidadGubernamentalRepositoryAsync _entidadGubernamentalRepositoryAsync;
        private readonly IMapper _mapper;

        public DeleteEntidadGubernamentalCommandHandler(IEntidadGubernamentalRepositoryAsync entidadGubernamentalRepositoryAsync, IMapper mapper)
        {
            _entidadGubernamentalRepositoryAsync = entidadGubernamentalRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteEntidadGubernamentalCommand request, CancellationToken cancellationToken)
        {
            var res = await _entidadGubernamentalRepositoryAsync.EliminarEntidad(request.CodigoEntidad);
            return new Response<int>(res, Constantes.SUCCEDED_DELETE_HEAD);
        }
    }
}
