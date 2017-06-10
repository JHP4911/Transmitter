using System.Collections.Generic;

namespace Data
{
    public class FieldValueMainModel
    {
        public List<FieldValueModel> Values { get; set; }
    }
    public class FieldValueModel
    {
        public string FieldKey { get; set; }
        public string FieldValue { get; set; }
    }
}