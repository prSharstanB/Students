using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class Registering
    {
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public DateTime RegDate { get; set; }
        public int  RegType { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
