using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        // GET: api/Team
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            Tools tool = new Tools();
            return tool.GetTeamsObject();
        }

        // GET: api/Team/5
        [HttpGet("{team_id}", Name = "GetTeam_id")]
        public List<Team> Get(string team_id)
        {
            Tools tool = new Tools();
            return tool.GetTeam(team_id,"");
        }

        // GET: api/Team/Ferrari
        [HttpGet("Team/{Team_name}")]
        public List<Team> Get(string Team_name,int extra_param = -1) //extra_param serviva solo per poter distinguere dalla richiamata API precedente
        {
            Tools tool = new Tools();
            return tool.GetTeam("",Team_name);
        }

        // GET: api/Team/5/FERRARI
        [HttpGet("{team_id}/{team_name}")]
        public List<Team> Get(string team_id, string team_name)
        {
            Tools tool = new Tools();
            return tool.GetTeam(team_id, team_name);
        }

        // POST: api/Team
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
