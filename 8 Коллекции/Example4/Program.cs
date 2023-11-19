using System.Xml.Linq;

namespace Example4
{
    class Program
    {
        private const string DataFilePath = "..\\worker.xml";

        static void Main(string[] args)
        {
            Worker worker = new Worker("Oshen Vajniy", "Sovietskiy St.", 5.6, 1.2, "89002327777", "88707444444");


            XElement person = new XElement("Person");
            XAttribute name = new XAttribute("name", worker.FIO);


            XElement address = new XElement("Address");

            XElement street = new XElement("Street", worker.Street);
            XElement houseNumber = new XElement("HouseNumber", worker.HouseNumber);
            XElement flatNumber = new XElement("FlatNumber", worker.FlatNumber);


            XElement phones = new XElement("Phones");

            XElement mobilePhone = new XElement("MobilePhone", worker.MobilePhone);
            XElement flatPhone = new XElement("FlatPhone", worker.FlatPhone);


            address.Add(street, houseNumber, flatNumber);
            phones.Add(mobilePhone, flatPhone);

            person.Add(name);
            person.Add(address, phones);

            person.Save(DataFilePath);
        }
    }
}