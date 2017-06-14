using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Field : Base
    {
        public string Name { get; set; }
        [ForeignKey("Unit")]
        public Guid UnitId { get; set; }

        public Unit Unit { get; set; }

        [ForeignKey("FieldType")]
        public Guid FieldTypeId { get; set; }
        public FieldType FieldType { get; set; }
        [JsonIgnore]
        public virtual ICollection<FieldValue> FieldValue { get; set; }
        public virtual ICollection<FieldRegulation> FieldRegulation { get; set; }
        public virtual SetDataField SetDataField { get; set; }

    }
}
