using Data.Entity;
using System;
using System.Data.Entity;
using System.Linq;

namespace Bussines
{
    public interface IDashBoardService : IBaseService<DashBoard>
    {
        object GetChartsByUserId(string userId);
        object GetInfo(string ıd);
    }
}