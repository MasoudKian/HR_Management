using System;

namespace HR_Management.Application.Exeptions
{
    public class NotFoundExeption : ApplicationException
    {
        public NotFoundExeption(string name , object key)
            :base($"{name}({key}) was not found!")
        {
            
        }
    }
}
