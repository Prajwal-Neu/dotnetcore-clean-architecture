using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Commands;
using MediatR;

namespace CleanArchitecture.Application.Person.CommandHandlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePerson, Domain.Entities.Person>
    {
        private readonly IPersonRepository _personRepository;

        public UpdatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Domain.Entities.Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
        {
            var person = new Domain.Entities.Person
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email
            };
            return await _personRepository.UpdatePerson(person);

        }
    }
}
