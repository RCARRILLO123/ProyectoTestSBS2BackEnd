using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Entidad;
using Test.Application.Interfaces.Repositories;
using Test.Infraestructure.Persistence.Data;

namespace Test.Infraestructure.Persistence.Repositories
{
    public class EntidadGubernamentalRepositoryAsync : IEntidadGubernamentalRepositoryAsync
    {
        private readonly IConnectionFactory _connectionFactory;
        public EntidadGubernamentalRepositoryAsync(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<int> RegistrarEntidad(EntidadRequest entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "USP_Create_Entidad";
            var parameters = new DynamicParameters();
            parameters.Add("@cDescripcion", entity.Descripcion);
            parameters.Add("@nIdEntidad", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("nIdEntidad");

        }

        public async Task<int> ActualizarEntidad(EntidadRequest entity)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "USP_Update_Entidad";
            var parameters = new DynamicParameters();
            parameters.Add("@nId", entity.Id);
            parameters.Add("@cDescripcion", entity.Descripcion);
            parameters.Add("@nIdEntidad", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("nIdEntidad");

        }
        public async Task<int> EliminarEntidad(int codigo)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "USP_Delete_Entidad";
            var parameters = new DynamicParameters();
            parameters.Add("@nId", codigo);
            parameters.Add("@nIdEntidad", DbType.String, direction: ParameterDirection.Output);
            await connection.QueryAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return parameters.Get<int>("nIdEntidad");

        }
        public async Task<IReadOnlyList<EntidadResponse>> ListarEntidad(string descripcion)
        {
            using var connection = _connectionFactory.GetConnection;
            var query = "USP_Listar_Entidad";
            var parameters = new DynamicParameters();
            parameters.Add("@cDescripcion", descripcion);
            var products = await connection.QueryAsync<EntidadResponse>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return products.AsList();
        }
    }
}