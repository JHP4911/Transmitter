using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
    }
}
