using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class StudentData
    {
        static private List<Student> testStudents;
        static public List<Student> TestStudents {
            get {
                resetStudents();
                return testStudents; 
            } private set {
                if (testStudents == null)
                {
                    resetStudents();
                }
            }
        }
        static private void resetStudents()
        {
            testStudents = new List<Student>();
            testStudents
                .Add(new Student("Jaklin", "Krasimirova", "Basheva", 1, 1, 1, "signed", "121219071", 3, 30));
            testStudents
                .Add(new Student("Mariika", "Petrova", "Ivanova", 1, 1, 1, "signed", "121219555", 3, 35));
            testStudents
                .Add(new Student("Draganka", "Dimitrova", "Georgieva", 1, 1, 1, "signed", "121219555", 3, 31));

        }
    }
}
