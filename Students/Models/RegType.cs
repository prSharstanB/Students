using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Models
{
    class RegType
    {
        public int  Id { get; set; }
        public int Type { get; set; }
        public bool isDeleted { get; set; }

        public ICollection<Registering>  Registerings { get; set; }
    }
}
