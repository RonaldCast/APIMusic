using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services.PersonService
{
    public class PersonService : IPersonService
    {
        public Task<UserPersonDTO> GetPersonAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UserPersonDTO> InsertPersonAsync(UserPersonSigninDTO userPerson)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> UpdatePersonAsync(PersonDTO id)
        {
            throw new NotImplementedException();
        }
    }
}
