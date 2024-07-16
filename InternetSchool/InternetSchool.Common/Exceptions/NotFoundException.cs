using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetSchool.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
            :base() { }
        public NotFoundException(string message)
            :base(message) { }
        public NotFoundException(int id)
            : base($"there is no such object with {id} id") { }
    }
}
