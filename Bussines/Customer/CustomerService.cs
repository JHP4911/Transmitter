using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bussines
{
    public class CustomerService :BaseService<Customer>, ICustomerService
    {
        IRepository<Customer> _repo;
        public CustomerService(IRepository<Customer> repo) : base(repo)
        {
            _repo = repo;
        }

    }
}
