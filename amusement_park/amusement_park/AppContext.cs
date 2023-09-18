
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amusement_park
{
    internal class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppContext() : base("DefaultConnection")
        {

        }
    }
}
