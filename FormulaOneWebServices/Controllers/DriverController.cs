﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormulaOneDLL;

namespace FormulaOneWebServices
{
    [Route("api/Driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        // GET: api/Driver
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            Tools tool = new Tools();
            return tool.GetDriversObject();
        }

        // GET: api/Driver/5
        [HttpGet("{Driver_id}")]
        public List<Driver> Get(int Driver_id)
        {
            Tools tool = new Tools();
            return tool.GetDriver(Driver_id,""); //se ho solo id come parametro, faccio che imposto il parametro surname a ""
        }

        //GET:  api/Driver/COGNOME
        [HttpGet("{Driver_Surname}")]
        public List<Driver> Get(string Driver_Surname)
        {
            Tools tool = new Tools();
            return tool.GetDriver(0,Driver_Surname); //se ho solo il surname come parametro, imposto id del parametro a 0
        }

        // POST: api/Driver
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        // PUT: api/Driver/5
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
