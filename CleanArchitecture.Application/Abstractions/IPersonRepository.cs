using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Abstractions
{
    public interface IPersonRepository
    {
        Task<ICollection<Domain.Entities.Person>> GetAll();

        Task<Domain.Entities.Person> GetPersonById(int personId);

        Task<Domain.Entities.Person> AddPerson(Domain.Entities.Person toCreate);

        Task<Domain.Entities.Person> UpdatePerson(Domain.Entities.Person toUpdate);

        Task<int> DeletePerson(int personId);
    };
}
