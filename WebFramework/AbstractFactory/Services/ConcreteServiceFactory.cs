using System;

namespace WebFramework.AbstractFactory.Services
{
    class ConcreteServiceFactory : AbstractServiceFactory
    {
        public override StartupServiceFactory AddService()
        {
            throw new NotImplementedException();
        }
    }
}
