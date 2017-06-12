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
        IRepository<FieldType> _fieldTypeRepo;
        public FieldService(IRepository<Field> repo,
            IRepository<FieldType> fieldTypeRepo) : base(repo)
        {
            _repo = repo;
            _fieldTypeRepo = fieldTypeRepo;
        }

        public IList<FieldType> getFeildTypes()
        {
            return _fieldTypeRepo.GetAll().ToList();
        }
    }
}
