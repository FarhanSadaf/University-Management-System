using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Model
{
    class StudentWithDept
    {
        public int SId { set; get; }
        public string SName { set; get; }
        public string SRollNo { set; get; }
        public int SAge { set; get; }
        public string SPhoneNo { set; get; }
        public string SEmail { set; get; }
        public int DId { set; get; }
        public string DCode { set; get; }
        public string DName { set; get; }
    }
}
