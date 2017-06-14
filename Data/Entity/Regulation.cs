using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Regulation : Base
    {
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<RegulationFields> Field { get; set; }
    }
}
