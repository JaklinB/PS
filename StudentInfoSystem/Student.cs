using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class Student
    {
        public string forename { get; set; }
        public string middlename { get; set; }
        public string surname { get; set; }
        public int faculty { get; set; }
        public int department { get; set; }
        public int degree { get; set; }
        public string status { get; set; }
        public string facultyNum { get; set; }
        public int year { get; set; }
        public int group { get; set; }

        public Student(string fore, string middle, string sur, int fac, int dep, int deg, string st, string facN, int y, int gr)
        {
            forename = fore;
            middlename = middle;
            surname = sur;
            department = dep;
            degree = deg;
            status = st;
            facultyNum = facN;
            year = y;
            group = gr;
            faculty = fac;
        }
        override
        public String ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Student: " + forename + " " + surname);
            sb.Append("\n");
            sb.Append("Department No: " + department);
            sb.Append("\n");
            sb.Append("Year of studies: " + year);
            sb.Append("\n");
            sb.Append("Group: " + group);
            sb.Append("\n");

            return sb.ToString();
        }
    }
}
