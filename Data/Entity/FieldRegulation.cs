using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class FieldRegulation : Base
    {
        [ForeignKey("Field")]
        public Guid FieldId { get; set; }

        [ForeignKey("Regulation")]
        public Guid RegulationId { get; set; }

        public CONDITION_TYPE ConditionType { get; set; }
        public string Condition { get; set; }
        public string SetDataFieldValue { get; set; }
        public string DefaultFieldValue { get; set; }
        public  Regulation Regulation { get; set; }
        public  Field Field { get; set; }
    }
}
