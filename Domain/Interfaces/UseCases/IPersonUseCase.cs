using Domain.Dtos;

namespace Domain.Interfaces.UseCases;

public interface IPersonUseCase
{
    Task<CreatePersonResponse> Create(CreatePersonRequest p);
}
