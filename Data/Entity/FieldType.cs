using System.Collections;
using System.Collections.Generic;

namespace Data.Entity
{
    public class FieldType : Base
    {
        public string Name { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
    }
}