using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFramework.AbstractFactory.Services
{
    class ClientFactory
    {
        private AbstractServiceFactory _A;
        public ClientFactory(AbstractServiceFactory factory)
        {
            _A = factory;
        }
        public void Run()
        {
            _A.AddService();
        }

    }
}
