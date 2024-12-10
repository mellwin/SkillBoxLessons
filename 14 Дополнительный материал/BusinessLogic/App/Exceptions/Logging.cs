namespace App
{
    public static class Logging
    {
        private const string logFilePath = "..\\LogFile.txt";
        public static void Info(string exception)
        {
            try
            {
                string text = $"{DateTime.Now} {exception}\n";
                File.AppendAllText(logFilePath, text);
            }
            catch { } //Не критический функционал
        }
    }
}
