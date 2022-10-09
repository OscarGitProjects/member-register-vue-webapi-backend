using MemberRegister.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemberRegister.Data.Data
{
    /// <summary>
    /// Class that create some default data and saves it to context
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// Method seed data to the database
        /// </summary>
        /// <param name="builder">Reference to ModelBuilder</param>
        /// <returns></returns>
        public static async Task InitSeedAsync(ModelBuilder builder)
        {
            if (builder == null) 
                throw new ArgumentNullException($"{nameof(SeedData)}->InitSeedAsync(). Reference to ModelBuilder is null");

            DateTime dtNow = DateTime.Now;

            builder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    Firstname = "Fornamn 1",
                    Lastname = "Efternamn 1",
                    Address = "Adress 1",
                    Postcode = "111111",
                    Postaladdress = "Postort 1",
                    CreationDate = dtNow,
                    LastUpdatedDate = dtNow,
                },
                new Member
                {
                    Id = 2,
                    Firstname = "Fornamn 2",
                    Lastname = "Efternamn 2",
                    Address = "Adress 2",
                    Postcode = "222222",
                    Postaladdress = "Postort 2",
                    CreationDate = dtNow,
                    LastUpdatedDate = dtNow,
                },
                new Member
                {
                    Id = 3,
                    Firstname = "Fornamn 3",
                    Lastname = "Efternamn 3",
                    Address = "Adress 3",
                    Postcode = "333333",
                    Postaladdress = "Postort 3",
                    CreationDate = dtNow,
                    LastUpdatedDate = dtNow,
                }
            );
        }
    }
}
