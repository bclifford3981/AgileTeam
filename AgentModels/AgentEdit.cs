using AgentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentModels
{
    public class AgentEdit
    {
        public int AgentId { get; set; }

        public string LastName { get; set; }

        public FieldType FieldType { get; set; }
    }
}
