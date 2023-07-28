using MediatR;

namespace CleanArchitecture.Application.Person.Queries
{
    public class GetAllPersons: IRequest<ICollection<Domain.Entities.Person>>
    {
    }
}
