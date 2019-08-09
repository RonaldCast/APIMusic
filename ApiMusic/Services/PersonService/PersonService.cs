using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent;

namespace Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonService()
        {
        }

        public PersonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserPersonDTO> GetPersonAsync(Guid id)
        {
            UserPersonDTO userPerson = new UserPersonDTO();
            try
            {
                Person person = await _dbContext.People.Where(p => p.Id == id).SingleOrDefaultAsync();

                if (person != null)
                {
                    User user = await _dbContext.Users.Where(p => p.Id == person.UserID).SingleOrDefaultAsync();
                    person.User = user;

                    userPerson = new UserPersonDTO()
                    {
                        Id = person.Id,
                        Name = person.Name,
                        LastName = person.LastName,
                        Country = person.Country,
                        Gender = person.Gender,
                        UserId = user.Id,
                        Email = user.Email,

                    };
                }
                else
                {
                    userPerson = null;
                }

            }
            catch 
            {

                userPerson = null;
            }
            return userPerson; 

        }

        public async Task<UserPersonDTO> InsertPersonAsync(Person userPerson)
        {

            UserPersonDTO infoUser = new UserPersonDTO();
            try
            {
                userPerson.User.Id = Guid.NewGuid();
                userPerson.Id = Guid.NewGuid();
                await _dbContext.Users.AddAsync(userPerson.User);
                await _dbContext.People.AddAsync(userPerson);
                var savePerson = await _dbContext.SaveChangesAsync();
                if (savePerson == 2)
                {
                    List<Person> people = await _dbContext.People.ToListAsync();
                    List<User> users  = await _dbContext.Users.ToListAsync();

                    UserPersonDTO newPerson = (from person in people
                                     join user in users
                                     on person.UserID equals user.Id
                                     select new UserPersonDTO()
                                     {
                                         Id =  person.Id,
                                         Name = person.Name,
                                         LastName = person.LastName,
                                         Country = person.Country,
                                         Gender = person.Gender,
                                         UserId = user.Id,
                                         Email = user.Email,

                                     }).FirstOrDefault();

                    infoUser = newPerson;
                }
                else
                {
                    infoUser = null;
                }
               
            }
            catch 
            {
                return infoUser = null;
            }
           
                return infoUser;
        }

        public async Task<PersonDTO> UpdatePersonAsync(Guid id, Person person)
        {
            PersonDTO personUpdate = new PersonDTO();
            try
            {
                Person personForUpdate = await _dbContext.People.Where(p => p.Id == id).SingleOrDefaultAsync();

                if (personForUpdate != null)
                {
                    personForUpdate.Name = person.Name;
                    personForUpdate.LastName = person.LastName;
                    personForUpdate.Country = person.Country;
                    personForUpdate.Gender = person.Gender;

                    var save = await _dbContext.SaveChangesAsync();

                    if (save == 1)
                    {
                        personUpdate.Name = person.Name;
                        personUpdate.LastName = person.LastName;
                        personUpdate.Country = person.Country;
                        personUpdate.Gender = person.Gender;
                    }
                  
                }
                else
                {
                    personUpdate = null;
                }
            }
            catch 
            {

                personUpdate = null;
            }

            return personUpdate;
        }
    }
}
