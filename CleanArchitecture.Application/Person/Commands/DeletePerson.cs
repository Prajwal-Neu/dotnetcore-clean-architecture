using MediatR;

namespace CleanArchitecture.Application.Person.Commands
{
    public class DeletePerson : IRequest<int>
    {
        public int Id { get; set; }
    };
}
