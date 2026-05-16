using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Source.Database.Tables
{
    [Table("users", Schema = "Security")]
    public class UserTable
    {
        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string? Email { get; set; }
        [StringLength(512)]
        public string? Password { get; set; }
        [StringLength(128)]
        public string Salt { get; set; }
        public bool State { get; set; }
    }
}
