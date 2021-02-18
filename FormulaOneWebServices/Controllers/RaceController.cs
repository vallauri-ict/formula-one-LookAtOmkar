using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/Race")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        // GET: api/Race
        [HttpGet]
        public IEnumerable<Races> Get()
        {
            Tools tool = new Tools();
            return tool.GetRacesObject();
        }

        // GET: api/Race/5
        [HttpGet("{id}")]
        public List<Races> Get(int id)
        {
            Tools tool = new Tools();
            return tool.GetRace(id);
        }

        // POST: api/Race
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Race/5
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
