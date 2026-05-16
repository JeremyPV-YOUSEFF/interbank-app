using interbank_data.Source.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Source.Database.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonTable>().HasData(

                new PersonTable
                {
                    Id = 1,
                    Name = "Tomy",
                    LastName = "Lanparo",
                    DocumentType = "DNI",
                    DocumentNumber = "87654321",
                    CellPhoneNumber = "999666331",
                    BussinessName = "",
                    Type = "Empleado",
                    State = true
                }
            );

            modelBuilder.Entity<UserTable>().HasData(
                new UserTable { Id = 1, PersonId = 1, Email = "admin@vetadmin.com", Password = "123456", State = true, Salt = "qweretrt21212" }
            );
        }
    }
}
