using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Entidad;

namespace Test.Application.Interfaces.Repositories
{
    public  interface IEntidadGubernamentalRepositoryAsync
    {
        Task<int> RegistrarEntidad(EntidadRequest entity);
        Task<int> EliminarEntidad(int codigo);
        Task<int> ActualizarEntidad(EntidadRequest entity);
        Task<IReadOnlyList<EntidadResponse>> ListarEntidad(string descripcion);
    }
}
