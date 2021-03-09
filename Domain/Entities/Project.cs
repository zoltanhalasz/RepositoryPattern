using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeadDeveloperId { get; set; }

        [JsonIgnore]
        public Developer LeadDeveloper { get; set; }
    }
}
