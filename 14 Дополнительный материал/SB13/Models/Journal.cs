namespace SB13.Models
{
    internal class Journal
    {
        public int Id { get; set; }
        public DateTime DateTimeCreate { get; set; }
        public string Message { get; set; }

        public static event Action<string> OnJournal;

        Journal(string message)
        {
            Message = message;
            DateTimeCreate = DateTime.Now;
        }

        public Journal() { }
    }
}
