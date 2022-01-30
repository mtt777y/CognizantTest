using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognizantTest.DataEntities;
using NLog;
using Newtonsoft.Json;

namespace CognizantTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaderController : ControllerBase
    {
        protected DbSets _context;
        protected ILogger _logger;

        public LoaderController(DbSets dbSets, ILogger logger)
        {
            _context = dbSets;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult PostData([FromBody] Envelope envelope)
        {
            try
            {
                Common.RecursiveParser.Parse(_context, _logger, envelope.Data);

                return StatusCode(200);
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500);
            }

        }

    }

    public class Envelope
    {
        public string Data { get; set; }
    }
}
