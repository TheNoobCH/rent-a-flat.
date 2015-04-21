using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentAFlat.Models
{
    public class RentAFlatDBContext : DbContext
    {
        public DbSet<User> Movies { get; set; }
    }
}