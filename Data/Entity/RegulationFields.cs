using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class RegulationFields: Base
    {
        [ForeignKey("Field")]
        public Guid FieldId { get; set; }
        [JsonIgnore]
        public Field Field { get; set; }
        [ForeignKey("Regulation")]
        public Guid RegulationId { get; set; }
        [JsonIgnore]
        public Regulation Regulation { get; set; }
    }
}