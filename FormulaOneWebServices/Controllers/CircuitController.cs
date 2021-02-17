using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

namespace FormulaOneWebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : ControllerBase
    {
        // GET: api/Circuit
        [HttpGet]
        public IEnumerable<Circuit> Get()
        {
            Tools tool = new Tools();
            return tool.GetCircuitsObject();
        }

        // GET: api/Circuit/5
        [HttpGet("{Circuit_id}", Name = "GetCircuit")]
        public List<Circuit> Get(string Circuit_id)
        {
            Tools tool = new Tools();
            return tool.GetCircuit(Circuit_id);
        }

        // POST: api/Circuit
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Circuit/5
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
