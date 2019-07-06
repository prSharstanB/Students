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

    class IntroductiveFullName
    {
        public int Id { get; set; }
        public String FullName { get; set; }
        public DateTime IntDate { get; set; }
        public int Avg { get; set; }
        public bool isDeleted { get; set; }
        public String SubjectName { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

    class IntroductiveAvgStudyYear
    {
        public int Id { get; set; }
        public int Avg { get; set; }
        public bool isDeleted { get; set; }
        public int StudYear { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

    class IntroductiveForChart
    {
        public double TotalAvg { get; set; }
        public bool isDeleted { get; set; }
        public int IntDate { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
    //class IntroductiveFoDate
    //{
    //    public int IntDate { get; set; }
       
    //}

}
