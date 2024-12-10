using System;
using System.Collections.Generic;
using System.Text;

namespace SB10._2
{
    public class Consultant
    {
        private protected string name;
        private protected string surname;
        private protected string secondName;
        private protected string mobilePhone;
        private protected string passport;

        public Consultant(string _name, string _surname, string _secondName, string _mobilePhone, string _passport)
        {
            name = _name;
            surname = _surname;
            secondName = _secondName;
            mobilePhone = _mobilePhone;
            passport = _passport;
        }
        protected Consultant() { }

        private string Name { get { return this.name; } }
        private string Surname { get { return this.surname; } }
        private string SecondName { get { return this.secondName; } }
        private string MobilePhone { get { return this.mobilePhone; } set { mobilePhone = value; } }
        private string Passport { get => "**********"; }



        public string ClientInformation()
        {
            return String.Format("Консультант:  Name:{0,15} | Surname:{1,15} |  SecondName:{2, 15} | MobilePhone:{3, 12} | Passport:{4, 10}",
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
