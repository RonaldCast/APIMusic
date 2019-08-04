using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserService
{
    public interface IUserService
    {
        Task<UserDTO> GetUser(Guid id);
    }
}
