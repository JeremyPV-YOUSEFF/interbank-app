using interbank_domain.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_domain.Auth.Services
{
    public interface IAuthenticationService
    {
        public LoginResponse Login(LoginRequest login);
    }
}
