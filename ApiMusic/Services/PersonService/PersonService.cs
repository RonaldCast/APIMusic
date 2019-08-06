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
        public PersonService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<UserPersonDTO> GetPersonAsync(Guid id)
        {
            throw new NotImplementedException();
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
                                         Name = person.Name,
                                         LastName = person.Name
                                     }).FirstOrDefault();

                    infoUser = newPerson;
                }
                else
                {
                    infoUser = null;
                }
               
            }
            catch (Exception)
            {
                return infoUser = null;
            }
           
                return infoUser;
        }

        public Task<PersonDTO> UpdatePersonAsync(Person id)
        {
            throw new NotImplementedException();
        }
    }
}
