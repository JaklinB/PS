using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public static UserRoles currentUserRole { get; private set; }
        public static String currentUserUsername { get; private set; }
        private String Username;
        private String Password;
        private String ErrorMessage = "LoginValidationException";
        public delegate void ActionOnError(String errorMsg);
        private ActionOnError error;

        public LoginValidation(String un, String pw, ActionOnError error)
        {
            this.Username = un;
            this.Password = pw;
            this.error = error;
        }
        public bool ValidateUserInput(ref User user)
        {
            currentUserRole = (UserRoles)1;
            if (emptyCheck(Username))
            {
                ErrorMessage = "No username entered.";
                error(ErrorMessage);
                return false;
            }

            if (emptyCheck(Password))
            {
                ErrorMessage = "No password entered.";
                error(ErrorMessage);
                return false;
            }

            if (lengthCheck(Username))
            {
                ErrorMessage = "Username entered is shorter than 5 characters.";
                error(ErrorMessage);
                return false;
            }

            if (lengthCheck(Password))
            {
                ErrorMessage = "Password entered is shorter than 5 characters.";
                error(ErrorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(Password, Username);
            if (user == null)
            {
                ErrorMessage = "Invalid data. No such user exists.";
                error(ErrorMessage);
                return false;
            }
            /*user = UserData.TestUsers;*/
            currentUserRole = (UserRoles)user.Role;
            currentUserUsername = Username;
            Logger.LogActivity("Успешен Login");
            return true;
        }

        private bool emptyCheck(String str)
        {
            Boolean empty = str.Equals(String.Empty);
            return empty;
        }

        private bool lengthCheck(String str)
        {
            Boolean tooShort = str.Length < 5;
            return tooShort;
        }
    }

    
}
