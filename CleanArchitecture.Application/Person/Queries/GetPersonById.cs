using MediatR;

namespace CleanArchitecture.Application.Person.Queries
{
    public class GetPersonById : IRequest<Domain.Entities.Person>
    {
        public int Id { get; set; }
    };
}
