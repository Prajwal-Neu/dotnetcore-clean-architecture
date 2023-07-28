using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Commands;
using MediatR;

namespace CleanArchitecture.Application.Person.CommandHandlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePerson, int>
    {
        private readonly IPersonRepository _personRepository;

        public DeletePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<int> Handle(DeletePerson request, CancellationToken cancellationToken)
        {
            return await _personRepository.DeletePerson(request.Id);
            
        }
    }
}
