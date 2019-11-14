using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace PDFApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("getPDF/{id}")]
        public ActionResult getPDF(string id)
        {
           
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"Files\"+id+".pdf");
            if (!System.IO.File.Exists(path)) return BadRequest(new { 
                Message="File not found"
            });

            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/pdf");
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        
    }
}
