using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.PersonService
{
    public interface IPersonService
    {
        Task<UserPersonDTO> InsertPersonAsync(UserPersonSigninDTO userPerson);
        Task<UserPersonDTO> GetPersonAsync(Guid id);
        Task<PersonDTO> UpdatePersonAsync(PersonDTO id);
    }
}
