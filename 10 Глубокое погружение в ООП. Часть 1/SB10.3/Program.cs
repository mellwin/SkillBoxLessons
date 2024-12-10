using System;

namespace SB10._3
{
    class Program
    {
        static IEmployee currentEmployee;

        static void Main(string[] args)
        {
            ChooseJopTitle();

            bool doing = true;

            do
            {
                if (currentEmployee is Manager)
                {
                    doing = ManagerActionsMenu();
                }

                if (currentEmployee is Consultant && !(currentEmployee is Manager))
                {
                    doing = ConsultantActionsMenu();
                }
            }
            while (doing);


        }

        static void ChooseJopTitle()
        {
            Console.WriteLine("1 - консультант\n" +
                              "2 - менеджер\n");
            int ChoosenProfile = Convert.ToInt32(Console.ReadLine());

            switch (ChoosenProfile)
            {
                case 1: currentEmployee = new Consultant(); break;
                case 2: currentEmployee = new Manager(); break;
            }
        }

        private static bool ManagerActionsMenu()
        {
            Console.Write(
                "1 - Показать всех клиентов\n" +
                "2 - Изменить фамилию\n" +
                "3 - Изменить имя\n" +
                "4 - Изменить отчество\n" +
                "5 - Изменить телефон\n" +
                "6 - Изменить паспорт\n" +
                "7 - Добавить клиента\n" +
                "8 - Выйти из программы\n"
                );

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    currentEmployee.ShowAllClients();
                    break;
                case "2":
                    EditLastName();
                    break;
                case "3":
                    EditLastName();
                    break;
                case "4":
                    EditSurname();
                    break;
                case "5":
                    EditPhone();
                    break;
                case "6":
                    EditPassport();
                    break;
                case "7":
                    AddNewClient();
                    break;
                case "8":
                    return false;
                default:
                    return false;
            };
            return true;
        }
        private static bool ConsultantActionsMenu()
        {
            Console.Write(
                "1 - Показать всех клиентов\n" +
                "2 - Изменить телефон\n" +
                "3 - Выйти из программы\n"
                );

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    currentEmployee.ShowAllClients();
                    break;
                case "2":
                    EditPhone();
                    break;
                case "3":
                    return false;
                default:
                    Console.WriteLine("Что-то пошло не так!");
                    return false;
            }
            return true;
        }
        public static void EditPhone()
        {
            var client = currentEmployee.ReadClient(ChooseClientIdForEdit());

            Console.WriteLine("Введите телефон (не пустой):");

            client.MobilePhone = Console.ReadLine();

            currentEmployee.EditClient(client);
        }

        public static void EditLastName()
        {
            var client = currentEmployee.ReadClient(ChooseClientIdForEdit());

            Console.WriteLine("Введите фамилию:");

            client.SecondName = Console.ReadLine();

            currentEmployee.EditClient(client);
        }

        public static void EditFirstName()
        {
            var client = currentEmployee.ReadClient(ChooseClientIdForEdit());

            Console.WriteLine("Введите имя:");

            client.Name = Console.ReadLine();

            currentEmployee.EditClient(client);
        }

        public static void EditSurname()
        {
            var client = currentEmployee.ReadClient(ChooseClientIdForEdit());

            Console.WriteLine("Введите отчество:");

            client.Surname = Console.ReadLine();

            currentEmployee.EditClient(client);
        }

        public static void EditPassport()
        {
            var client = currentEmployee.ReadClient(ChooseClientIdForEdit());

            Console.WriteLine("Введите паспортные данные:");

            client.Passport = Console.ReadLine();

            currentEmployee.EditClient(client);
        }
        public static int ChooseClientIdForEdit()
        {
            Console.WriteLine("Введите id клиента для редактирования:");
            return int.Parse(Console.ReadLine());
        }

        public static void AddNewClient()
        {
            var client = new Client();

            Console.WriteLine("Введите имя:");

            client.Name = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");

            client.SecondName = Console.ReadLine();

            Console.WriteLine("Введите отчество:");

            client.Surname = Console.ReadLine();

            Console.WriteLine("Введите телефон (не пустой):");

            client.MobilePhone = Console.ReadLine();

            Console.WriteLine("Введите паспортные данные:");

            client.Passport = Console.ReadLine();

            currentEmployee.AddClient(client);

        }
    }
}
