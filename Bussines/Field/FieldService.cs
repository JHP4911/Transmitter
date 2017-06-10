using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bussines
{
    public class FieldService : BaseService<Field>, IFieldService
    {
        IRepository<Field> _repo;
        public FieldService(IRepository<Field> repo) : base(repo)
        {
            _repo = repo;
        }

    }
}
