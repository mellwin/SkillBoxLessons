using System;
using System.Collections.Generic;
using System.Text;

namespace SB10._1
{
    public class Consultant
    {
        private string name;
        private string surname;
        private string secondName;
        private string mobilePhone;
        private string passport;

        public Consultant(string _name, string _surname, string _secondName, string _mobilePhone, string _passport)
        {
            name = _name;
            surname = _surname;
            secondName = _secondName;
            mobilePhone = _mobilePhone;
            passport = _passport;
        }

        public string Name { get { return this.name; } }
        public string Surname { get { return this.surname; } }
        public string SecondName { get { return this.secondName; } }
        public string MobilePhone { get { return this.mobilePhone; } set { mobilePhone = value; } }
        public string Passport { get => "**********"; }



        public string ClientInformation()
        {
            return String.Format("Name:{0,15} | Surname:{1,15} |  SecondName:{2, 15} | MobilePhone:{3, 12} | Passport:{4, 10}",
                this.Name, 
                this.Surname,
                this.SecondName,
                this.MobilePhone,
                this.Passport);
        }

        public void SetNewMobilePhone(string newMobilePhone)
        {
            this.MobilePhone = newMobilePhone;
        }
    }
}
