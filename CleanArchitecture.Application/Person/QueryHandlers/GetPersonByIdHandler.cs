using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Queries;
using MediatR;

namespace CleanArchitecture.Application.Person.QueryHandlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonById, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Domain.Entities.Person> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonById(request.Id);
        }
    };
}
