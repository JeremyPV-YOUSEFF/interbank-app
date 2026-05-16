using interbank_domain.Auth.Models;
using interbank_domain.Auth.Repositories;
using interbank_domain.Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Auth.Repository
{
    public class AuthenticationRepositoryImpl : IAuthenticationRepository
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationRepositoryImpl(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public LoginResponse Login(LoginRequest login)
        {
            return _authService.Login(login);
        }
    }
}
