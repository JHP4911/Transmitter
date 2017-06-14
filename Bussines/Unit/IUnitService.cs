using Data.Entity;
using System;
using System.Data.Entity;
using System.Linq;

namespace Bussines
{
    public interface IUnitService : IBaseService<Unit>
    {
        object GetFieldForCharts(string unitId);
    }
}