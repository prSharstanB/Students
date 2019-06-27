using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class DataContext : DbContext
    {
        public DataContext () : base ("Data Source =.; Initial Catalog = StudentDB; Integrated Security = true") 
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Registering> Registerings { get; set; }
        public DbSet<RegType> RegTypes { get; set; }
        public DbSet<Subject>  Subjects { get; set; }
        public DbSet<Introductive> Introductives { get; set; }
       

    }
}
