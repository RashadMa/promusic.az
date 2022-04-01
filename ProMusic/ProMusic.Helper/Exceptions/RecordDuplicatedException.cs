using System;
namespace ProMusic.Helper.Exceptions
{
    public class RecordDuplicatedException:Exception
    {
        public RecordDuplicatedException(string message) : base(message)
        {
        }
    }
}
