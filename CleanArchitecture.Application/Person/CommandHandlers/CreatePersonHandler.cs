using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Commands;
using Mapster;
using MediatR;

namespace CleanArchitecture.Application.Person.CommandHandlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePerson, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Domain.Entities.Person> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = request.Adapt<Domain.Entities.Person>();
            return await _personRepository.AddPerson(person);
        }
    };
}