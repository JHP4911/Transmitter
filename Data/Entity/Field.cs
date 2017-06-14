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
        public CONDITION_TYPE ConditionType { get; set; }
        public string Condition { get; set; }
        public string SetDataFieldValue { get; set; }
        public string DefaultFieldValue { get; set; }
        public virtual ICollection<Regulation> Regulation { get; set; }

        [ForeignKey("Unit")]
        public Guid UnitId { get; set; }

        public Unit Unit { get; set; }

        [ForeignKey("FieldType")]
        public Guid FieldTypeId { get; set; }
        public virtual FieldType FieldType { get; set; }

        [JsonIgnore]
        public virtual ICollection<FieldValue> FieldValue { get; set; }

       

    }
}
