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
    class FullName
    {
       
        public int Id { get; set; }
        public bool isDeleted { get; set; }
        public String fullName { get; set; }
        public DateTime RegDate { get; set; }
        public int RegType { get; set; }
        public String RegTypeChange {
            get
            {
                if (RegType == 0) return "تسجيل كمستجد";
                else if(RegType==1)
                {
                    return "إيقاف التسجيل";
                }
                else
                {
                    return "استئناف التسجيل";
                }
            }
            set { ; }
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
