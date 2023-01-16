namespace DddCqrs.Crud.Application.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class DuplicateIdentityException : Exception
    {
        public DuplicateIdentityException()
        {
            HResult = 101;
        }

        public override string Message => "This user has registered before!";

    }
}
