using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs.Account.Response;
using Test.Application.Exceptions;
using Test.Application.Wrappers;
using Test.Domain.Settings;
using Microsoft.Extensions.Configuration;
namespace Test.Application.Features.Usuario.Commands
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
        {
            private readonly IMapper _mapper;
            private readonly JWTSettings _jwtSettings;
            private IConfiguration _configuration;

            public AuthenticateCommandHandler(
                IMapper mapper,
                IOptions<JWTSettings> jwtSettings,
                IConfiguration configuration

                )
            {
                _mapper = mapper;
                _jwtSettings = jwtSettings.Value;
                _configuration = configuration;
            }

            public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
            {
                string vUser = _configuration["User"].ToString();
                string vPass = _configuration["Password"].ToString();

                if (vUser != request.Username || vPass != request.Password)
                {
                    throw new ApiException($"Usuario o contraseña incorrecta.");
                }

                AuthenticationResponse user = new AuthenticationResponse()
                {
                    Username = request.Username,
                    Password = request.Password
                };



                JwtSecurityToken jwtSecurityToken = GenerateJWToken(user);
                user.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                return new Response<AuthenticationResponse>(user, $"Usuario autenticado");
            }

            private JwtSecurityToken GenerateJWToken(AuthenticationResponse user)
            {
                var roleClaims = new List<Claim>();
                roleClaims.Add(new Claim("roles", "Administrador"));

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Name, user.Username),
                new Claim("user", user.Username),
                new Claim("password", user.Password),
            }
                .Union(roleClaims);

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtSettings.Issuer,
                    audience: _jwtSettings.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddYears(3),
                    signingCredentials: signingCredentials);
                return jwtSecurityToken;
            }
        }

    }
}

