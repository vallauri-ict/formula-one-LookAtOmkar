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
        [HttpGet("{team_id}", Name = "GetTeam")]
        public List<Team> Get(string team_id)
        {
            Tools tool = new Tools();
            return tool.GetTeam(team_id);
        }

        [HttpGet("{param}", Name = "GetDto")]
        public Team GetDTO(string param)
        {
            Tools tool = new Tools();
            
            return;
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
