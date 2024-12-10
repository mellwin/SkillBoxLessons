using System;

namespace SB10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Consultant cons = new Consultant("Иван", "Иванович", "Иванов", "79123347564", "1949293949");

            Console.WriteLine(cons.ClientInformation());

            cons.SetNewMobilePhone("new7921123");

            Console.WriteLine(cons.ClientInformation());
        }
    }
}
