using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcGrid.Models.Manager
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new Builder());
        }
    }

    public class Builder:CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Country> countryList = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                Country country = new Country();
                country.Name = FakeData.PlaceData.GetCountry();
                countryList.Add(country);
                context.Countries.Add(country);
            }
            context.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                Staff staff = new Staff();
                staff.FirstName = FakeData.NameData.GetFirstName();
                staff.LastName = FakeData.NameData.GetSurname();
                staff.Age = FakeData.NumberData.GetNumber(10, 90);

                Random random = new Random();
                int deger = random.Next(0, 10);

                staff.Country = countryList[deger];

                context.Staffs.Add(staff);
            }
            context.SaveChanges();
        }
    }
}