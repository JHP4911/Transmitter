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
        IRepository<DashBoard> _repo;

        IRepository<FieldType> _fieldTypeRepo;

        public DashBoardService(IRepository<DashBoard> repo
           , IRepository<FieldType> fieldTypeRepo) : base(repo)
        {
            _fieldTypeRepo = fieldTypeRepo;
            _repo = repo;

        }
        public object GetChartsByUserId(string userId)
        {
            var data = _repo.GetById(userId)
               .Field
               .Select(x => new UnitFieldsCharts()
               {
                   Name = x.Name,
                   fieldType = x.FieldType.Name,
                   fieldValue = ChartModel.create(new ChartModel()
                   {
                       label = x.Name,
                       data = x.FieldValue
                                       .OrderBy(d => d.CreateTime)
                                       .Select(s => ChartValues.create(new ChartValues()
                                       { CreateTime = s.CreateTime.ToString("dd/mm HH:MM"), Value = s.Value }))
                                       .Take(10)
                                       .ToList()
                   })
               });
            return data;
        }
    }
}
