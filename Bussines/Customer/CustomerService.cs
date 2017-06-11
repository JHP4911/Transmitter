using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Newtonsoft.Json;

namespace Bussines
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        IRepository<Unit> _unitRepo;
        public CustomerService(
            IRepository<Customer> repo, 
            IRepository<Unit> unitRepo) : base(repo)
        {
            _repo = repo;
            _unitRepo = unitRepo;
        }

        public object getCustomerForNavigation(string customerId)
        {
            var Id = Guid.Parse(customerId);
            var result = _unitRepo.GetAll()
                 .Where(x => x.CustomerId == Id)
                 .Select(x => new
                 {
                     name = x.Name,
                     id = x.Id,
                     fieldCount = x.Fields.Count
                 }).ToList();
            return result;
        }
    }
}
