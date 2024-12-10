using System;
using System.Collections.Generic;
using System.Text;

namespace SB10._2
{
    public class Manager : Consultant
    {
        public Manager(string _name, string _surname, string _secondName, string _mobilePhone, string _passport)
            : base(_name, _surname, _secondName, _mobilePhone, _passport)
        {
        }

        public Manager() : base() { }

        private string Name { get { return base.name; } set { base.name = value; } }
        private string Surname { get { return base.surname; } set { base.surname = value; } }
        private string SecondName { get { return base.secondName; } set { base.secondName = value; } }
        private string MobilePhone { get { return base.mobilePhone; } set { base.mobilePhone = value; } }
        private string Passport { get { return base.passport; } set { base.passport = value; } }

        public new string ClientInformation()
        {
            return String.Format("Менеджер:  Name:{0,15} | Surname:{1,15} |  SecondName:{2, 15} | MobilePhone:{3, 12} | Passport:{4, 10}",
                this.Name,
                this.Surname,
                this.SecondName,
                this.MobilePhone,
                this.Passport);
        }

        public void UpdateClientsInfo(string name, string surname, string secondName, string mobilePhone, string passport)
        {
            this.Name = name;
            this.Surname = surname;
            this.SecondName = secondName;
            this.MobilePhone = mobilePhone;
            this.Passport = passport;
        }
    }
}
