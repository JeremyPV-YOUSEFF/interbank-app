using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_domain.Errors
{
    public class MessageExeption : Exception
    {
        public MessageExeption(string message) : base(message)
        {
        }
    }
}
