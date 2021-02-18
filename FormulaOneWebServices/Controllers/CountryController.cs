using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;


namespace FormulaOneWebServices
{
    [Route("api/Country")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        // GET: api/Country
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            Tools db = new Tools();
            return db.GetCountriesObject();
        }

        // GET: api/Country/it
        [HttpGet("{isoCode}", Name = "Get")]
        public List<Country> Get(string isoCode)
        {
            Tools db = new Tools();
            return db.GetCountry(isoCode);
        }

 

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/Country/5
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
