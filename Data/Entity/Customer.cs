using Newtonsoft.Json;
using System.Collections.Generic;

namespace Data.Entity
{
    public class Customer : Base
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Unit> Units { get; set; }
        [JsonIgnore]
        public virtual ICollection<ApplicationUser> Users { get; set; }       

    }
}
