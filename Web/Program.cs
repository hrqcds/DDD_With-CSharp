
using Application;
using Data;
using Domain.Dtos;
using Domain.Errors;
using Domain.Interfaces.UseCases;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

DataExtensions.AddEntityFramework(builder.Services);
DataExtensions.AddRepositories(builder.Services);
ApplicationExtensions.AddUseCases(builder.Services);
var app = builder.Build();

app.MapGet("/", () =>
{
    return "Rodando";
});

app.MapPost("/test", async ([FromServices] IPersonUseCase personUseCase, [FromBody] CreatePersonRequest request) => {
    try
    {
        var response = await personUseCase.Create(request);
        return Results.Created("Person created!!",response);
    }
    catch (UseCaseException ex)
    {
        return ex.StatusCode switch
        {
            400 => Results.BadRequest(ex.ErrorDescription),
            404 => Results.NotFound(ex.ErrorDescription),
            _ => Results.UnprocessableEntity()

        };
    }
    catch (Exception ex)
    {
        return Results.UnprocessableEntity(ex);
    }
});


app.Run();
