using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Data.Entity
{
    public class Unit : Base
    {
        public string Name { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [JsonIgnore]
        public  Customer Customer { get; set; }

        public virtual ICollection<Field> Fields { get; set; }

    }
}
