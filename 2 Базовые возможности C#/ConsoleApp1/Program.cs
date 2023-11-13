using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string FullName = "Иванов Иван Иванович";
            int age = 25;
            string email = "ii.ivanov@mail.ru";
            double programScore = 4.5;
            double mathScore = 5;
            double physicsScore = 4.7;


            double sumScore;
            double avgScore;
            // Exersice 1
            // 1 вариант
            //Console.WriteLine($"ФИО: {FullName}");
            //Console.WriteLine($"Возраст: {age}");
            //Console.WriteLine($"Электронная почта: {email}");
            //Console.WriteLine($"Баллы по программированию: {programScore}");
            //Console.WriteLine($"Баллы по математике: {mathScore}");
            //Console.WriteLine($"Баллы по физике: {physicsScore}");

            // 2 Вариант
            string pattern = $"ФИО: {FullName} \nВозраст: {age} \nЭлектронная почта: {email} \nБаллы по программированию: {programScore} \nБаллы по математике: {mathScore} \nБаллы по физике: {physicsScore}";
            Console.WriteLine(pattern, FullName, age, email, programScore, mathScore, physicsScore);


            Console.ReadKey();

            // Exersice 2
            sumScore = programScore + mathScore + physicsScore;
            avgScore = (programScore + mathScore + physicsScore) / 3;
            Console.WriteLine($"Сумма баллов: {sumScore}");
            Console.WriteLine($"Средний балл: {avgScore}");

            Console.ReadKey();
        }
    }
}
