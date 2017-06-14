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
    public class DashBoard : Base
    {

        [ForeignKey("Field")]
        public Guid FieldId { get; set; }
        public virtual Field Field { get; set; }
        public Guid UserId { get; set; }


    }
}
