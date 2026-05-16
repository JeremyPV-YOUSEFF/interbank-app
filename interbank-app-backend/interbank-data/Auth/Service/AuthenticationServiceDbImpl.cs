using interbank_data.Auth.Utils;
using interbank_data.Source.Database;
using interbank_domain.Auth.Models;
using interbank_domain.Auth.Services;
using interbank_domain.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Auth.Service
{
    public class AuthenticationServiceDbImpl : IAuthenticationService
    {

        private readonly InterbankDbContext _db;
        private readonly ILogger<AuthenticationServiceDbImpl> _logger;
        public AuthenticationServiceDbImpl(InterbankDbContext db, ILogger<AuthenticationServiceDbImpl> logger)
        {
            _db = db;
            _logger = logger;
        }
        public LoginResponse Login(LoginRequest login)
        {
            var user = _db.Person.Where(f => f.DocumentNumber == login.Dni).FirstOrDefault();

            if (user == null)
            {
                throw new Exception("Credenciales incorrectas");
            }

            /*login.Password = GenerateSaltedHashUtil.GenerateSaltedHash(login.Password, user.Salt);*/

            if (login.Password == null)
            {
                throw new MessageExeption("soy nulo");
            }

            var request = _db.User.Join(
                _db.Person,
                (u) => u.PersonId,
                (p) => p.Id,
                (u, p) => new { user1 = u, person1 = p }
                ).Where(
                    (upr) => upr.person1.DocumentNumber == login.Dni && upr.user1.Password == login.Password && upr.user1.State
                ).FirstOrDefault();

            if (request == null)
            {
                throw new MessageExeption($"Credenciales incorrectas pero correctas");
            }


            var profile = new UserAppProfile
            {
                Id = request.person1.Id,
                Name = request.person1.Name,
                LastName = request.person1.LastName,
                UserId = request.user1.Id,
                Email = request.user1.Email,
               
            };

            return new LoginResponse
            {
                Token = GenerateSaltedHashUtil.GetJWT(profile),
            };
        }
    }
}
