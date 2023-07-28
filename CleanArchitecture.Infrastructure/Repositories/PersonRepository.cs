using CleanArchitecture.Application.Abstractions;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonDbContext _context;

        public PersonRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<Person> AddPerson(Person toCreate)
        {
            _context.Person.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task<int> DeletePerson(int personId)
        {
            var person = _context.Person
                .FirstOrDefault(p => p.Id == personId);

            if (person is null) throw new Exception("Invalid Operation");

            _context.Person.Remove(person);

            await _context.SaveChangesAsync();
            return personId;
        }

        public async Task<ICollection<Person>> GetAll()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> GetPersonById(int personId)
        {
            var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
            if (person is null) throw new Exception("Invalid Operation");
            return person;
        }

        public async Task<Person> UpdatePerson(Person toUpdate)
        {
            var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == toUpdate.Id);

            if (person is null) throw new Exception("Invalid Operation");

            person.Name = toUpdate.Name;
            person.Email = toUpdate.Email;

            await _context.SaveChangesAsync();

            return person;
        }
    };
}
