namespace DddCqrs.Crud.Application.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DuplicateEmailException : Exception
    {
        public DuplicateEmailException()
        {
            HResult = 100; 
        }

        public override string Message => "Email address has been registered!";

    }

}
