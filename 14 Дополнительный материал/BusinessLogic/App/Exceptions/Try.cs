namespace App
{
    public static class Try
    {
        public static event Action<string> ExceptionNotification;

        public static void InvokeExceptionNotification(string message)
        {
            ExceptionNotification?.Invoke(message);
        }

        public static bool TryExecute(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                if (ex is IUseEx useEx)
                {
                    //Ошибка для пользователя                    
                    ExceptionNotification?.Invoke(useEx.DefaultMessage);
                    Console.WriteLine(useEx.DefaultMessage);
                }
                else
                {
                    //Ошибка в лог и сообщение для пользователя
                    Logging.Info(ex.Message);
                    ExceptionNotification?.Invoke("Что-то пошло не так. Обратитесь в службу поддержки");                   
                    Console.WriteLine("Что-то пошло не так. Обратитесь в службу поддержки");
                }
                return false;
            }
        }
    }
}
