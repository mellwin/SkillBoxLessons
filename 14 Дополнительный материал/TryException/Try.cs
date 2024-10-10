namespace TryException
{
    public static class Try
    {

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
                    //MessageBox.Show(useEx.DefaultMessage);
                    Console.WriteLine(useEx.DefaultMessage);
                }
                else
                {
                    Logging.Info(ex.Message);

                    //MessageBox.Show("Что-то пошло не так. Обратитесь в службу поддержки");
                    Console.WriteLine("Что-то пошло не так. Обратитесь в службу поддержки");
                }
                return false;
            }
        }
    }
}
