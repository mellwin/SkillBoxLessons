namespace Example4
{
    public struct Worker
    {
        public string FIO { get; set; }

        public string Street { get; set; }

        public double HouseNumber { get; set; }

        public double FlatNumber { get; set; }

        public string MobilePhone { get; set; }

        public string FlatPhone { get; set; }

        public Worker(string fio, string street, double houseNumber, double flatNumber, string mobilePhone, string flatPhone)
        {
            this.FIO = fio;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.FlatNumber = flatNumber;
            this.MobilePhone = mobilePhone;
            this.FlatPhone = flatPhone;
        }
    }
}
