using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentData
{
    public enum FieldType { Field, Office, Lab }
    public class Agent
    {

        [Key]
        public int AgentId { get; set; }

        [Required]
        public string LastName { get; set; }

       [Required]
        public Guid DbId { get; set; }

        public FieldType FieldType { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
