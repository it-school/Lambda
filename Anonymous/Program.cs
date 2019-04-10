﻿using System;
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
        private static void SetLogin()
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
        }

        static void Main()
        {
            SetLogin();

            Console.Write("Введите пароль: ");
            string password1 = Console.ReadLine();
            Console.Write("Повторите пароль: ");
            string password2 = Console.ReadLine();

            // Используем лямбда выражение
            BoolPassword bp = (s1, s2) => s1 == s2;

            if (bp(password1, password2))
            {
                Random ran = new Random();
                string resCaptcha = "";
                for (int i = 0; i < 10; i++)
                    resCaptcha += (char)ran.Next(0, 100);
                Console.WriteLine("Введите код: " + resCaptcha);
                string resCode = Console.ReadLine();

                // Реализуем блочное лямбда-выражение
                Captcha cp = (s1, s2) =>
                {
                    if (s1 == s2)
                        Console.WriteLine("Регистрация удалась!");
                    else
                        Console.WriteLine("Не переживайте, в следующий раз получится :)");
                    return;
                };
                cp(resCaptcha, resCode);
            }
            else
                Console.WriteLine("Регистрация провалилась. Пароли не совпадают");

        }
    }
}
