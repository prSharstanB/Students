using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class Subject
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Introductive>  Introductives { get; set; }
    }
}
