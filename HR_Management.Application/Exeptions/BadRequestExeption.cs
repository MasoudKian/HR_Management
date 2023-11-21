using System;

namespace HR_Management.Application.Exeptions
{
    public class BadRequestExeption : ApplicationException
    {
        public BadRequestExeption(string message ) : base( message ) 
        {
            
        }
    }
}
