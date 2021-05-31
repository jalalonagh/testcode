using Data.Contracts;
using Entities.Customer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Services.User
{
    public class CustomerLogin
    {
        private IUnitOfWork _uow;
        private readonly  DbSet<Entities.Customer.Customer> _Customer;

        public CustomerLogin(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
            _Customer = uow.Set<Entities.Customer.Customer>();
        }

        //public CustomerLogin(int customerId)
        //{
        //    _Customer.get
        //}

    }
}
