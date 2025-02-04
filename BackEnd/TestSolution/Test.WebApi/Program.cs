using Test.Infraestructure.Persistence;
using Test.WebApi.Extensions;
using Microsoft.OpenApi.Models;
using Test.Infraestructure.Shared;
using Test.Application;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

#pragma warning disable ASP0000 
var provider = builder.Services.BuildServiceProvider();
#pragma warning restore ASP0000 
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddPersistenceInfrastructure(configuration);
builder.Services.AddSharedInfrastructure(configuration);

// Add services to the container.
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "Allow", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddApiVersioningExtension();
builder.Services.AddHealthChecks();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplicationLayer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Test.WebApi", Version = "v1" });
    options.SwaggerDoc(name: "Test.WebApi",
       new OpenApiInfo { Title = "Test.WebApi", Version = "v1" });
    options.AddSecurityDefinition(name: "Bearer", securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("Allow");
app.UseAuthentication();

app.UseAuthorization();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");
app.MapControllers();

app.Run();
