namespace App
{
    public class NotFoundCustumersEx : Exception, IUseEx
    {
        public string DefaultMessage => "Нет доступных клиентов для заполнения";

        public NotFoundCustumersEx()
        {
            this.InvokeExceptionNotification();
        }
    }
}
