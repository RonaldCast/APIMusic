using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models;
using Services.AuthServices;

namespace ApiMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            this.configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserDTO userLogin)
        {
            var userInfo = await _authService.LoginUserAsync(userLogin);

            if (userInfo != null)
            {
                return Ok(new { token = GeneralTokenJWt(userInfo)});
            }
            else
            {
                return Unauthorized();
            }
        }

        private object GeneralTokenJWt(User usuarioInfo)
        {
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS 
            //todo la informacion que se desea guardar del usuario
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                new Claim("id", usuarioInfo.Id.ToString()),
                new Claim("emailAddress", usuarioInfo.Email)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.Now,
                    // expira a la 24 horas.
                    expires: DateTime.Now.AddHours(24)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );
            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}