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
    public class DashBoardService : BaseService<DashBoard>, IDashBoardService
    {

        IRepository<FieldType> _fieldTypeRepo;
        IRepository<Customer> _customerRepo;

        public DashBoardService(IRepository<DashBoard> repo,
            IRepository<FieldType> fieldTypeRepo,
            IRepository<Customer> customerRepo) : base(repo)
        {
            _fieldTypeRepo = fieldTypeRepo;
            _repo = repo;
            _customerRepo = customerRepo;

        }
        public object GetChartsByUserId(string userId)
        {
            _repo.Context.Configuration.LazyLoadingEnabled = true;
            var Id = Guid.Parse(userId);
            //var data = _repo.GetAll()
            //    .Where(x => x.UserId == Id)
            //    .ToList()
            //    .Select(x => new 
            //    {
            //        Name = x.Field.Name,
            //        fieldType = x.FieldId.ToString(),//x.Field.FieldType.Name,
            //        fieldValue = x.Field.FieldValue.ToList().Select(s=>new object[] {s.CreateTime.ToString("dd/mm HH:MM"), s.Value })

            //    });
            var data = _repo.GetAll()
              .Where(x => x.UserId == Id)
              .ToList()              
              .Select(x => new
              {
                  Id = x.Id,
                  Name = x.Field.Name,
                  fieldType = _fieldTypeRepo.GetById(x.Field.FieldTypeId).Name,
                  fieldValue = new object[]
                  {
                     new {
                         label = x.Field.Name,
                         data = x.Field.FieldValue.ToList()
                         .OrderByDescending(o=>o.CreateTime)
                         .Take(10)
                         .OrderBy(o=>o.CreateTime)
                         .Select(s => new object[] {
                             s.CreateTime.ToString(),
                             s.Value
                         }) }
                  }

              }).ToList();
            return data;
        }

        public object GetInfo(string Id)
        {

            _customerRepo.Context.Configuration.LazyLoadingEnabled = true;
            var f = 0;
            var customer = _customerRepo.GetById(Id);
            customer.Units.ToList().ForEach(x => { f += x.Fields.Count(); });
            return new
            {
                unitCount = customer.Units.Count,
                fieldCount = f,
                phone = customer.Phone,
                users = customer.Users.Count()
            };

        }
    }
}
