using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Worker
    {
        public int Id { get; set; }

        public DateTime DateTimeRecord { get; set; }

        public string FIO { get; set; }

        public int Age { get; set; }

        public double High { get; set; }

        public DateTime BirthDate { get; set; }

        public string BirthPlace { get; set; }

        public Worker(int Id, DateTime DateTimeRecord, string FIO, int Age, double High, DateTime BirthDate, string BirthPlace) 
        {
            this.Id = Id;
            this.DateTimeRecord = DateTime.Now;
            this.FIO = FIO;
            this.Age = Convert.ToInt32((DateTimeRecord- BirthDate));
            this.High = High;
            this.BirthDate = BirthDate;
            this.BirthPlace = BirthPlace;
        }

        public Worker(int Id, DateTime DateTimeRecord) :
            this(Id, DateTimeRecord, String.Empty, 0, 0, new DateTime(1900, 1, 1, 0, 0, 0), String.Empty)
        {

        }
    }
}
