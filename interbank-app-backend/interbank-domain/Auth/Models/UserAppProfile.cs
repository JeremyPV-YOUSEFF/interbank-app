using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_domain.Auth.Models
{
    public class UserAppProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
