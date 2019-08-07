using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServices
{
    public interface IAuthService
    {
        Task<User> LoginUserAsync(UserDTO user);
    }
}
