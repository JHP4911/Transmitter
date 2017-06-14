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
        public string label { get; set; }
        public List<List<object>> data { get; set; }
    }

    public class ChartValues
    {
        public string Value { get; set; }
        public string CreateTime { get; set; }
        public static List<object> create(ChartValues model)
        {
            List<object> d = new List<object>();
            d.Add(model.CreateTime);
            d.Add(model.Value);
            return d;
        }
    }
}