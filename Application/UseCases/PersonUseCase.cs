using System.Net;
using Domain.Dtos;
using Domain.Entities;
using Domain.Errors;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCases;

namespace Application.UseCases;

public class PersonUseCase : IPersonUseCase
{
    private readonly IPersonRepository _personRepository;
    public PersonUseCase(IPersonRepository personRepository) 
    {
        _personRepository = personRepository;
    }

    public async Task<CreatePersonResponse> Create(CreatePersonRequest p)
    {
        var personExist = await _personRepository.FindByEmail(p.Email);

        if (personExist != null)
        {
            throw new UseCaseException("Email já cadastrado no banco de dados", 400);
        }

        var result = await _personRepository.Add(new Person()
        {
            Name = p.Name,
            Age = p.Age,
            Email = p.Email,
        });

        return new CreatePersonResponse()
        {
            Id = result.Id,
            Name = result.Name,
            Age = result.Age,
            Email = result.Email,
            CreatedAt = (DateTime)result.CreatedAt!
        };
    }
}
