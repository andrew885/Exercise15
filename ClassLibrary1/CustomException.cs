using System;

namespace ClassLibrary1
{
    public class CustomException:System.Exception
    {
        public CustomException(string message) : base(message)
        {
            
        }
    }
}
