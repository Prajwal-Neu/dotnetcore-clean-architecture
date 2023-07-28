using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Commands;
using Mapster;
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
            var person = request.Adapt<Domain.Entities.Person>();
            return await _personRepository.UpdatePerson(person);
        }
    }
}