using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentServices
{
    public class AgentServices
    {
        public IEnumerable<AgentListItem> GetAgent()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Agents
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new AgentListItem
                                {
                                    AgentId = e.AgentId,
                                    LastName = e.LastName,
                                    CreatedUtc = e.CreatedUtc
                                }
                            );
                return query.ToArray();
            }

        }
    }
}
