using System;
using System.Collections.Generic;

namespace Data
{
    public class FieldValueMainModel
    {
        public string apiKey { get; set; }
        public List<FieldValueModel> records { get; set; }
    }
    public class FieldValueModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string date { get; set; }
    }
}