using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_domain.Auth.Models
{
    public class LoginRequest
    {
        public string Dni { get; set; }
        public string Password { get; set; }
    }
}
