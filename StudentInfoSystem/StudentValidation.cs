using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User us)
        {
            if (us.FacNum != null)
            {
                try
                {
                    Student st = (Student)(from stud in StudentData.TestStudents
                    where stud.facultyNum == us.FacNum
                    select stud).First();
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("\n\nStudent not found!\n");
                }
            }
                    return null;
        }
    }
}
