using AgentData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentModels
{
   public class AgentCreate
    {
        [Required]
        [MinLength(6, ErrorMessage = "Id must be at least 6 digits.")]
        [MaxLength(12, ErrorMessage ="Id cannot be more than 12 digits.")]
        public int AgentId { get; set; }
        public string LastName { get; set; }

        [Required]
        public FieldType FieldType { get; set; }
    }
}
