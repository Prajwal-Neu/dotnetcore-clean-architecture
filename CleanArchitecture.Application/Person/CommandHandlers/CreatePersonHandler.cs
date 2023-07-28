using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Commands;
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
            var person = new Domain.Entities.Person
            {
                Name = request.Name,
                Email = request.Email
            };

            return await _personRepository.AddPerson(person);
        }
    };
}
