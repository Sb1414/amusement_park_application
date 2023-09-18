using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace amusement_park
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Limitation> Limitations { get; set; }
        public DbSet<Attraction_rating> Attraction_ratings { get; set; }

        public AppContext() : base("DefaultConnection")
        {
            
        }
    }
}
