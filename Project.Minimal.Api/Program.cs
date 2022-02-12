using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project.Minimal.Api.Mapper;
using Project.Minimal.Application.Handler.Query;
using Project.Minimal.Application.Query;
using Project.Minimal.Infrastructure.Interface;
using Project.Minimal.Infrastructure.Product;
using System;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region SERVICE AUTOMAPPER
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });
    IMapper mapper = mappingConfig.CreateMapper();
#endregion


#region DI
    builder.Services.AddMediatR(typeof(GetAllProductQueryCommand).Assembly);
    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
    builder.Services.AddSingleton(typeof(IProductRepository<>), typeof(ProductRepository<>));
    builder.Services.AddScoped(typeof(GetAllProductQueryHandler));
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region MINIMAL API

    app.MapGet("/api/Products", ([FromServices] IMediator mediatr) =>
    {
        var result = mediatr.Send(new GetAllProductQueryCommand());

        return Results.Ok(result);
    })
        .WithName("Get All Product")
        .Produces((int)HttpStatusCode.OK)
        .Produces((int)HttpStatusCode.NoContent)
        .Produces((int)HttpStatusCode.BadRequest);

    app.MapGet("/api/Products/{product}", (Guid product, [FromServices] IMediator mediatr) =>
    {
        var result = mediatr.Send(new GetByIdProductQueryCommand(product));

        return Results.Ok(result);
    })
        .WithName("Get by a Product")
        .Produces((int)HttpStatusCode.OK)
        .Produces((int)HttpStatusCode.NoContent)
        .Produces((int)HttpStatusCode.BadRequest);
#endregion

app.Run();