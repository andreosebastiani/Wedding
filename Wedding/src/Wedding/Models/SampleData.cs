using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();
            
                var andreo = context.Attendee.Add(
                    new Attendee { FirstName = "Andreo", LastName = "Sebastiani", Email = "andreosebastiani@gmail.com",
                    IsAttending = true, MobileNumber = "724-650-4127", Note = "Excited"}).Entity;
               
                context.SaveChanges();
            
        }
    }
}
