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
        IRepository<FieldType> _fieldTypeRepo;
     
        public UnitService(IRepository<Unit> repo
            , IRepository<FieldType> fieldTypeRepo) : base(repo)
        {
            _fieldTypeRepo = fieldTypeRepo;
            _repo = repo;

        }
        public object GetFieldForCharts(string unitId)
        {
            //TODO: fieldtype lazyloadingle gelmeli neden gelmiyor çöz
            _repo.Context.Configuration.LazyLoadingEnabled = true;
            var data = _repo.GetById(unitId)
             .Fields
             .Select(x => new
             {
                 Id=x.Id,
                 Name = x.Name,
                 fieldType = _fieldTypeRepo.GetById(x.FieldTypeId).Name,
                 fieldValue = new object[]
                 {
                     new {
                         label = x.Name,
                         data = x.FieldValue.ToList().Select(s => new object[] { s.CreateTime.ToString("dd/mm HH:MM"), s.Value }) }
                 }

             });
            //object[] c;
            //var data = _repo.GetById(unitId)
            //   .Fields
            //   .Select(x => new UnitFieldsCharts()
            //   {
            //       Name = x.Name,
            //       fieldType = _fieldTypeRepo.GetById(x.FieldTypeId).Name,
            //       fieldValue = ChartModel.create(new ChartModel()
            //       {
            //           label = x.Name,
            //           data = x.FieldValue
            //                           .OrderBy(d => d.CreateTime)
            //                           .Select(s => ChartValues.create(new ChartValues()
            //                           { CreateTime = s.CreateTime.ToString("dd/mm HH:MM"), Value = s.Value }))
            //                           .Take(10)
            //                           .ToList()
            //       })
            //   });
            //var data = _repo.GetById(unitId)
            //    .Fields
            //    .Select(x => new UnitFieldsCharts()
            //    {
            //        Name = x.Name,
            //        fieldType = _fieldTypeRepo.GetById(x.FieldTypeId).Name,
            //        fieldValue = ChartModel.create(new ChartModel()
            //        {
            //            key = x.Name,
            //            values = x.FieldValue
            //                .Select(s => new ChartValues()
            //                { CreateTime = dateToLong(s.CreateTime), Value = s.Value, index = c++ })
            //                .OrderByDescending(d => d.CreateTime)
            //                .Take(10)
            //                .ToList()
            //        })
            //    });
            return data;
        }
        private long dateToLong(DateTime now)
        {
            long dateNumber = 1297380023295;
            long beginTicks = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

            long nowTicks = now.Ticks;
            var fark = (nowTicks - beginTicks) / 10000;

            DateTime dt = new DateTime(beginTicks + dateNumber * 10000, DateTimeKind.Utc);
            // MessageBox.Show(dt.ToLocalTime().ToString());

            long unixDate = 1297380023295;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var date = start.Ticks / 10000 + 1297380023295;
            return fark;
        }
    }
}
