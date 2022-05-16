using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAwesomeWebAPI
{
    public class MyService
    {
        private readonly ILogger<MyService> logger;

        public MyService(ILogger<MyService> logger)
        {
            this.logger = logger;
        }

        public string CreateFullName(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }
    }
}
