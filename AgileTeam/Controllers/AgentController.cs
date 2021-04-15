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
  
}
