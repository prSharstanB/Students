using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class Introductive
    {
        public int  Id { get; set; }
        public DateTime IntDate { get; set; }
        public int  Avg { get; set; }
        public bool isDeleted { get; set; }
        public int  StudentId { get; set; }
        public Student  Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
