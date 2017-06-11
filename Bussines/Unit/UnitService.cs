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
    public class UnitService : BaseService<Unit>, IUnitService
    {
        IRepository<Unit> _repo;
        public UnitService(IRepository<Unit> repo) : base(repo)
        {
            _repo = repo;
        }
       
    }
}
