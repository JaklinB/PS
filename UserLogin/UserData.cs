using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        static public List<User> TestUsers {
            get { 
                ResetTestUserData(); 
                return _testUsers; 
            } set {} 
        }

        static private List<User> _testUsers;
        static private void ResetTestUserData()
        {
        String[] usernames = new string[3] {"userAdmin", "mariika", "draganka" };
        String[] passwords = new string[3] {"passwordAdmin", "parolanamariika", "parolanadraganka" };
        String[] fakNums = new string[3] {"fnAdmin", "fnmariika", "fndraganka" };
        int[] roles = new int[3] {1, 4, 4};

            if (_testUsers == null)
            {
                _testUsers = new List<User>();
                for(int i = 0; i < 3; i++)
                {
                    _testUsers.Add(new User());
                    _testUsers[i].Username = usernames[i];
                    _testUsers[i].Password = passwords[i];
                    _testUsers[i].FacNum = fakNums[i];
                    _testUsers[i].Role = roles[i];
                    _testUsers[i].Created = DateTime.Now.Date;
                    _testUsers[i].Expires = DateTime.MaxValue.Date;
                }

            }
        }

        static public User IsUserPassCorrect(String pass, String user)
        {
            return (from testUser in TestUsers
                    where pass == testUser.Password &&
                    user == testUser.Username
                    select testUser).First();
        }

        static private void SetUserActiveTo(String usrnm, DateTime actvDt)
        {
            foreach (User us in TestUsers)
            {
                if (us.Username == usrnm)
                {
                    us.Expires = actvDt;
                    Logger.LogActivity("Промяна на активност на " + usrnm);
                }
            }
        }

        static public void printAllUsers()
        {
            Console.WriteLine("Общ брой: " + TestUsers.Count);
            foreach (User us in TestUsers)
            {
                Console.WriteLine(us.Username + " :: " + us.Created);
            }
        }

        static private void AssignUserRoles(String usrnm, UserRoles usrls)
        {
            foreach (User us in TestUsers)
            {
                if (us.Username == usrnm)
                {
                    us.Role = Convert.ToInt32(usrls);
                    Logger.LogActivity("Промяна на роля на " + usrnm);
                }
            }
        }

        static public void admin1(String usrnm, UserRoles usrls)
        {
            AssignUserRoles(usrnm, usrls);
        }

        static public void admin2(String usrnm, DateTime actvDt)
        {
            SetUserActiveTo(usrnm, actvDt);
        }
    }
}
