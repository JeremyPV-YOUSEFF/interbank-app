using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Source.Database.Tables
{
    [Table("persons", Schema = "Security")]
    public class PersonTable
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string? CellPhoneNumber { get; set; }
        public string? DocumentType { get; set; }
        public string? DocumentNumber { get; set; }
        public string? BussinessName { get; set; }
        public DateOnly? Birthday { get; set; }
        public bool State { get; set; }
        public string? Type { get; set; }
        public string? Gmail { get; set; }
    }
}
