using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ServiceAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {               

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] List<Entity> entities)
        {
            string sql = "";
            try
            {                
                MySqlConnection con = new MySqlConnection("Server=db;Port=3306;Database=entities;Uid=root;Pwd=supersecurepassword;");
                con.Open();

                string receivedMessage = JsonConvert.SerializeObject(entities);
                var cmd = new MySqlCommand("INSERT INTO messages_tb(message, idReference, referenceDateTime, createDateTime, updateDateTime) VALUES (@message, null, null, @date, null)", con);
                cmd.Parameters.AddWithValue("@message", receivedMessage);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);                
                cmd.ExecuteNonQuery();

                // Prendere tutti i valori e sommarli
                int somma = 0;
                foreach (Entity entity in entities)
                {
                    somma += entity.Value;
                }

                return Ok(somma);
                // TO DO: BUS MESSAGE
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
