using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class RecordOrSumNotSelectedUseEx : Exception, IUseEx
    {
        public string DefaultMessage => "Не заполнены поля";

        public RecordOrSumNotSelectedUseEx()
        {
            this.InvokeExceptionNotification();
        }
    }
}
