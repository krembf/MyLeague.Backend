using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLeagueProject.Database.Exceptions
{
    public class DuplicateEntryException : Exception
    {
        public DuplicateEntryException(string message)
        {
        }
    }
}
