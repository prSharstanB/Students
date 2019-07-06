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
        public int StudyYear { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<Introductive>  Introductives { get; set; }
    }
    class SubjectStudyYear
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public int StudyYearNum { get; set; }
        public bool isDeleted { get; set; }
        public String StudyYear {
            get
            {
                if (StudyYearNum == 1)
                    return "الأولى";
                else if (StudyYearNum == 2) return "الثانية";
                else if (StudyYearNum == 3) return "الثالثة";
                else if (StudyYearNum == 4) return "الرابعة";
                else if(StudyYearNum == 5)
                {
                    return "الخامسة";
                }
                else
                {
                    return "السادسة";
                }
            }
            set { ; }
        }
        public ICollection<Introductive> Introductives { get; set; }
    }
}
