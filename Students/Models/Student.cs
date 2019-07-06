using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class Student
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public int?  StuNumber { get; set; }
        public String Gender { get; set; }
        public bool isDeleted { get; set; }
        public  ICollection<Introductive> Introductives { set; get; }
        public ICollection<Registering> Registerings { set; get; }
    }

    class FullName
    {
        public int Id { get; set; }
        public String fullName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public int? StuNumber { get; set; }
        public String Gender { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Introductive> Introductives { set; get; }
        public ICollection<Registering> Registerings { set; get; }
    }
   
}
