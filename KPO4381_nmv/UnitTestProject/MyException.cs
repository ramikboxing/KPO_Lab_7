using Kpo4381_nmv.Utility;
using System;
using System.Runtime.Serialization;

namespace Kpo4381_nmv
{
    [Serializable]
    internal class MyException : Exception
    {
        public MyException()
        {
        }
        
        public MyException(string message) : base(message)
        {
            LogUtility.Error(message);
        }
        /*
        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }*/
    }
}