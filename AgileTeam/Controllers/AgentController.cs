using AgentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using System.Net;



namespace AgileTeam.Controllers
{
    
    public class AgentController : Controller
    {
        // GET: Agent
        public ActionResult Index()
        {
            return View();
        }
    }
    public IHttpActionResult Get()
    {
        AgentServices agentService = CreateAgentService();
        var agent = agentService.GetAgent();
        return Ok(agent);
    }
    [HttpPut]
    public async Task<IHttpActionResult> UpdateAgent([FromUri] int agentId, [FromBody] Agent updateAgent)
    {
        //check the ids if they match 
        if (id != updateAgent?.Id)
        {
            return BadRequest("Ids do not match");
        }
        //check model state
        if (ModelState.IsValid)
            return BadRequest(ModelState);

        // find the agent in the database
        Agent agent = await _context.Agent.FindAsync(id);

        //if it doesnt exist do somthing 
        if (agent is null)
            return NotFound();

        //update properties
        
        agent.AgentId = updateAgent.AgentId;
        agent.LastName = updateAgent.LastName;
        agent.DbId = updateAgent.DbId;
        agent.FieldType = updateAgent.Fieldype;
        agent.CreatedUtc = updateAgent.CreatedUtc;
        agent.MotifiedUtc = updateAgent.MotifiedUtc;


        // save the changes
        await _context.SaveChangesAsync();

        return Ok("The Agent information has been updated!");
    }

}
