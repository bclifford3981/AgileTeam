using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentServices
{
    public class AgentServices
    {
        private readonly Guid _userId;

        public AgentServices(Guid userid)
        {
            _userId = userid;
        }

        public bool CreateAgent(AgentCreate model)
        {
            var entity =
                new Agent()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Agent.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
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
                                    FieldType = (data.FieldType)
                                    CreatedUtc = e.CreatedUtc
                                }
                             );
                return query.ToArray();
            }
        }

        public AgentDetail GetAgentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Agents
                        .Single(e => e.AgentId == id && e.OwnerId == _userId);
                return
                    new AgentDetail
                    {
                        GetAgentById = entity.AgentId,
                        LastName = entity.LastName,
                        FieldType = (data.FieldType)entity.FieldType,
                        CreatedUtc = entity.CreatedUtc
                    }
            }
        }
        
    }
}
