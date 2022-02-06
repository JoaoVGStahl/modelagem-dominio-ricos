using System;
using System.Collections.Generic;
using System.Text;

namespace PontoSysStore.Core.DomainObjects
{
    public class DomainException : Exception
    {
        public DomainException()
        {

        }

        public DomainException(string mensagem) : base(mensagem)
        {

        }
        public DomainException(string mensagem, Exception innerException) : base(mensagem, innerException)
        {

        }
    }
}
