using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static int Main(string[] args)
        {
            
            Console.WriteLine("Enter username and password below\nUsername: ");
            String username = Console.ReadLine();
            Console.WriteLine("\nPassword:");
            String password = Console.ReadLine();

            void errorFunc(String str)
            {
                Console.WriteLine("EXCEPTION: " + str);
            }

            User user = null;
            LoginValidation lv = new LoginValidation(username, password, errorFunc);
            if (lv.ValidateUserInput(ref user))
            {
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine("\nLogged in, Administrator!\n\n");

                        showAdminMenu();
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Logged in, Student!");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Logged in, inspector!");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Logged in, Professor!");
                        break;
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Logged in, Guest User!");
                        break;
                }
            }
            Console.ReadLine();
            return 0;
            
        }

        private static void showAdminMenu()
        {
            Console.WriteLine("\n\n\nИзбрете опция:\n");
            Console.WriteLine("0: Изход\n");
            Console.WriteLine("1: Промяна на роля на потребител\n");
            Console.WriteLine("2: Промяна на активност на потребител\n");
            Console.WriteLine("3: Списък на потребителите\n");
            Console.WriteLine("4: Преглед на лог на активност\n");
            Console.WriteLine("5: Преглед на текуща активност\n");
            Console.WriteLine("6: Изтриване на активности преди въведена дата [mm/dd/yyyy]\n");


            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 0)
            {
                return;
            } else if (choice == 1)
            {
                Console.WriteLine("Въведете потребителско име и нова роля:");
                String username = Console.ReadLine().Trim();
                String role = Console.ReadLine().Trim();

                UserData.admin1(username, (UserRoles)Enum.Parse(typeof(UserRoles), role));
            } else if (choice == 2)
            {
                Console.WriteLine("Въведете потребителско име и нова активност:");
                String username = Console.ReadLine().Trim();
                DateTime atctvDt = DateTime.Parse(Console.ReadLine());

                UserData.admin2(username, atctvDt);
            } else if (choice == 3)
            {
                UserData.printAllUsers();
            } else if (choice == 4)
            {
                IEnumerable<string> activities = Logger.getLogActivity();
                foreach (string activity in activities)
                {
                    Console.WriteLine(activity);
                }
            } else if (choice == 5)
            {
                StringBuilder sb = new StringBuilder();
                Console.WriteLine("Enter a filter: ");
                string filter =  Console.ReadLine();
                IEnumerable<string> activities = Logger.getCurrentSessionActivities("2022");
                foreach (string activity in activities)
                {
                    sb.Append(activity).Append("\n");
                }
                Console.WriteLine(sb.ToString());
            }
            else if (choice == 6)
            {
                try
                {
                    Console.WriteLine("Моля въведете желаната дата [mm/dd/yyyy]:\n");
                    DateTime dt = DateTime.Parse(Console.ReadLine());
                    Logger.deleteByDate(dt);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Грешен формат!\n");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Въведете валидна дата!\n");
                }

            }


            showAdminMenu();
        }
    }
}
