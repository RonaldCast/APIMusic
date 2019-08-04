using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Services.UserService
{
    public class UserService : IUserService
    {
        public Task<UserDTO> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
