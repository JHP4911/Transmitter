using System;
using System.Collections.Generic;

namespace Bussines
{
    public class UnitFieldsCharts
    {
        public string Name { get; set; }
        public string fieldType { get; set; }
        public List<ChartModel> fieldValue { get; set; }
    }
    public class ChartModel
    {
        public static List<ChartModel> create(ChartModel model)
        {
            List<ChartModel> d = new List<ChartModel>();
            d.Add(model);
            return d;
        }
        public string key { get; set; }
        public List<ChartValues> values { get; set; }
    }

    public class ChartValues
    {
        public string Value { get; set; }
        public long CreateTime { get; set; }
    }
}