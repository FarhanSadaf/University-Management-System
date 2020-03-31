using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Model
{
    class StudentTakesCourse
    {
        public string SName { set; get; }
        public string SRoll { set; get; }
        public string CId { set; get; }
        public string CName { set; get; }
        public double CCredit { set; get; }
        public DateTime EnrollDate { set; get; }
    }
}
