namespace App
{
    public static class ExtensionForException
    {
        public static void InvokeExceptionNotification(this RecordOrSumNotSelectedUseEx message)
        {
            Try.InvokeExceptionNotification(message.DefaultMessage);
        }

        public static void InvokeExceptionNotification(this CustumerOrAccountNotChangedEx message)
        {
            Try.InvokeExceptionNotification(message.DefaultMessage);
        }

        public static void InvokeExceptionNotification(this NotFoundCustumersEx message)
        {
            Try.InvokeExceptionNotification(message.DefaultMessage);
        }
    }
}
