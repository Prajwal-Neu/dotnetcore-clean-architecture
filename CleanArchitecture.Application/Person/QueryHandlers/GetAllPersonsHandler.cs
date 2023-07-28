using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Application.Person.Queries;
using MediatR;

namespace CleanArchitecture.Application.Person.QueryHandlers
{
    public class GetAllPersonsHandler: IRequestHandler<GetAllPersons, ICollection<Domain.Entities.Person>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonsHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<ICollection<Domain.Entities.Person>> Handle(GetAllPersons request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetAll();
        }
    }
}
