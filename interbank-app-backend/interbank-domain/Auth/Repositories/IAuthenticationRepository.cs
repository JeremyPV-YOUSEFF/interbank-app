using interbank_domain.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_domain.Auth.Repositories
{
    public interface IAuthenticationRepository
    {
        public LoginResponse Login(LoginRequest login);
    }
}
