using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.PersonService
{
    public interface IPersonService
    {
        Task<UserPersonDTO> InsertPersonAsync(Person userPerson);
        Task<UserPersonDTO> GetPersonAsync(Guid id);
        Task<PersonDTO> UpdatePersonAsync(Guid id, Person person);
    }
}
