using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda
{
    // Создадим несколько делегатов имитирующих 
    // простейшую форму регистрации
    delegate int LengthLogin(string s);
    delegate bool BoolPassword(string s1, string s2);
    delegate void Captcha(string s1, string s2);

    class Program
    {
        private static string SetLogin()
        {
            Console.Write("Введите логин (от 4 до 25 символов): ");
            string login = Console.ReadLine();

            // Используем лямбда-выражение
            LengthLogin lengthLoginDelegate = s => s.Length;

            int lengthLogin = lengthLoginDelegate(login);
            if (lengthLogin > 25 || lengthLogin < 4)
            {
                Console.WriteLine("Некорректная длина логина!\n");

                // Рекурсия на этот же метод, чтобы ввести заново логин
                SetLogin();
            }

            return login;
        }

        static void Main()
        {
            string login = SetLogin();
            string password1 = "", password2 = "";
            bool isCorrectPasswords = false;
            do
            {
                do
                {
                    Console.Write("Введите пароль: ");
                    password1 = Console.ReadLine();
                } while (!Anonymous.Password.IsCorrectPassword(password1));

                Console.Write("Повторите пароль: ");
                password2 = Console.ReadLine();

                // Используем лямбда выражение
                BoolPassword bp = (s1, s2) => s1.Equals(s2);

                isCorrectPasswords = bp(password1, password2);
                if (!isCorrectPasswords)
                    Console.WriteLine("Регистрация провалилась. Пароли не совпадают");

            } while (!isCorrectPasswords);

            Console.WriteLine("Спасибо! Пароль подходит...");


            Random ran = new Random();
            string resCaptcha = "";
            for (int i = 0; i < 4; i++)
                resCaptcha += (char)ran.Next(33, 100);
            Console.WriteLine("Введите код: " + resCaptcha);
            string resCode = Console.ReadLine();

            // Реализуем блочное лямбда-выражение
            Captcha cp = (s1, s2) =>
            {
                if (s1.Equals(s2))
                    Console.WriteLine("Регистрация удалась!");
                else
                    Console.WriteLine("Не переживайте, в следующий раз получится :)");
                return;
            };

            cp(resCaptcha, resCode);
        }
    }
}

