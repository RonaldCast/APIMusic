using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.PersonService
{
    public interface IPersonService
    {
        Task<UserPersonDTO> InsertPerson(UserPersonDTO person);
        Task<UserPersonDTO> GetPerson(Guid id);
        Task<PersonDTO> UpdatePerson(PersonDTO id);
    }
}
