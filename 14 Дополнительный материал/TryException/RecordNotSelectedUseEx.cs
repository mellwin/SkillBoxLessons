namespace TryException
{
    class RecordNotSelectedUseEx : Exception, IUseEx
    {
        public string DefaultMessage => "Не выбрана запись!";
    }
}
