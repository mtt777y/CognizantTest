using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CognizantTest.DataEntities;
using NLog;
using Microsoft.EntityFrameworkCore;

namespace CognizantTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        protected DbSets _context;
        protected ILogger _logger;

        public VehicleController(DbSets dbSets, ILogger logger)
        {
            _context = dbSets;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<object> GetData()
        {
            return _context.Set<Vehicle>().Include(f => f.Model).Include(f => f.Brand).Include(f => f.Warehouse).
                            Select(f => new { Model = f.Model.Name, Brand = f.Brand.Name, Warehouse = f.Warehouse.Name, f.DateAdded, f.Licensed, f.Price, f.Id }).OrderBy(f => f.DateAdded);
        }

        [HttpGet("details")]
        public IEnumerable<object> GetData(bool lic)
        {
            return _context.Set<Vehicle>().Where(w => w.Licensed == lic).Include(f => f.Model).Include(f => f.Brand).Include(f => f.Warehouse).
                            Select(f => new { Model = f.Model.Name, Brand = f.Brand.Name, Warehouse = f.Warehouse.Name, f.DateAdded, f.Licensed, f.Price, f.Id }).OrderBy(f => f.DateAdded);
        }
    }
}
