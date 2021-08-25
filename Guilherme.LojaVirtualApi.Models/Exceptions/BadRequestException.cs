using System;
using System.Collections.Generic;
using System.Text;

namespace Guilherme.LojaVirtualApi.Models.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
