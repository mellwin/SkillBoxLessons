using App;

namespace App
{
    public class CustumerOrAccountNotChangedEx : Exception, IUseEx
    {
        public string DefaultMessage => "Нет доступных клиентов для заполнения";

        public CustumerOrAccountNotChangedEx()
        {
            this.InvokeExceptionNotification();
        }
    }
}