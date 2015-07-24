using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPITemplateProject.Models;

namespace WebAPITemplateProject.Tests.Models
{
    class TestDatabaseFactory : IDatabaseFactory
    {
        public IPersonRepository GetPersonRepository()
        {
            return new TestPersonRepository();
        }
    }
}
