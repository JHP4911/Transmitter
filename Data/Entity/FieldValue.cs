using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class FieldValue : Base
    {
        [ForeignKey("Field")]
        public Guid FieldId { get; set; }
        [JsonIgnore]
        public Field Field { get; set; }
        public string Value { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }
    }
}