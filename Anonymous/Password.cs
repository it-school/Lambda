using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous
{
    delegate bool CheckUpper(string s);
    delegate bool CheckLower(string s);
    delegate bool CheckDigit(string s);
    delegate bool CheckNotLetterOrDigit(string s);

    class Password
    {
        public static bool IsCorrectPassword(string password)
        {

            bool isCorrectPassword = false;

            CheckUpper checkUpper = (pass) =>
            {
                bool isCorrectPreviousAttempt = false;
                foreach (Char c in password) // UpperCase letter exists
                {
                    if (Char.IsUpper(c))
                    {
                        isCorrectPreviousAttempt = true;
                        break;
                    }
                }
                return isCorrectPreviousAttempt;
            };


            CheckLower checkLower = (pass) =>
            {
                bool isCorrectPreviousAttempt = false;
                foreach (Char c in password) // LowerCase letter exists
                {
                    if (Char.IsLower(c))
                    {
                        isCorrectPreviousAttempt = true;
                        break;
                    }
                }
                return isCorrectPreviousAttempt;
            };


            CheckDigit checkDigit = (pass) =>
            {
                bool isCorrectPreviousAttempt = false;
                foreach (Char c in password) // Digit letter exists
                {
                    if (Char.IsDigit(c))
                    {
                        isCorrectPreviousAttempt = true;
                        break;
                    }
                }
                return isCorrectPreviousAttempt;
            };

            CheckNotLetterOrDigit checkNotLetterOrDigit = (pass) =>
            {
                bool isCorrectPreviousAttempt = false;
                foreach (Char c in password) // Not Digit or Letter exists
                {
                    if (!Char.IsLetterOrDigit(c))
                    {
                        isCorrectPreviousAttempt = true;
                        break;
                    }
                }
                return isCorrectPreviousAttempt;
            };            

            if (password.Length >= Anonymous.Dictionary.MIN_PASSWORD_LENGTH)
                if (checkUpper(password) && checkLower(password) && checkDigit(password) && checkNotLetterOrDigit(password))
                    isCorrectPassword = true;


            return isCorrectPassword;
        }

    }
}
