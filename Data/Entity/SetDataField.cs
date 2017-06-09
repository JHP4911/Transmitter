using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class SetDataField : Base
    {
        [ForeignKey("Field")]
        public Guid FieldId { get; set; }
        public string Value { get; set; }
        public virtual Field Field { get; set; }
    }
}
