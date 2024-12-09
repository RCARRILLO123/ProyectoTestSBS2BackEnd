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

namespace Test.Application.Features.EntidadGubernamental.Queries
{
    public class GetEntidadGubernamentalAllQuery : IRequest<Response<IReadOnlyList<EntidadResponse>>>
    {
        public string? DescripcionEntidad { get; set; }

        public class GetEntidadGubernamentalAllQueryHandler : IRequestHandler<GetEntidadGubernamentalAllQuery, Response<IReadOnlyList<EntidadResponse>>>
        {
            private readonly IEntidadGubernamentalRepositoryAsync _entidadGubernamentalRepositoryAsync;
            private readonly IMapper _mapper;
            public GetEntidadGubernamentalAllQueryHandler(IEntidadGubernamentalRepositoryAsync entidadGubernamentalRepositoryAsync, IMapper mapper)
            {
                _entidadGubernamentalRepositoryAsync = entidadGubernamentalRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<EntidadResponse>>> Handle(GetEntidadGubernamentalAllQuery query, CancellationToken cancellationToken)
            {
                var descripcion = query.DescripcionEntidad?.Trim();
                var response = await _entidadGubernamentalRepositoryAsync.ListarEntidad(descripcion ?? string.Empty);

                return new Response<IReadOnlyList<EntidadResponse>>(response);
            }
        }
    }
}