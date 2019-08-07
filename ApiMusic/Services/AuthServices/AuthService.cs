using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistent;

namespace Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthService(ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }
        public async Task<User> LoginUserAsync(UserDTO user)
        {
            User response = new User();
            try
            {
                response = await _dbContext.Users
                    .Where(p => p.Password == user.Password && p.Email == user.Email)
                    .FirstOrDefaultAsync();
            }
            catch
            {
                response = null;
                
            }
            return response; 
        }
    }
}
