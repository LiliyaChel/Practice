using kidstrWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kidstrWebApi.Controllers
{
    //Load data
    [Route("[action]")]
    [ApiController]
    public partial class KidStrController : Controller
    {
        KidstrContext db;
        public KidStrController(KidstrContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddServ>>> AddServs() => await db.AddServs.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddServOrdr>>> AddServOrdrs() => await db.AddServOrdrs.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Age>>> Ages() => await db.Ages.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> Days() => await db.Days.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direction>>> Directions() => await db.Directions.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Employees() => await db.Employees.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guide>>> Guides() => await db.Guides.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordr>>> Ordrs() => await db.Ordrs.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Price>>> Prices() => await db.Prices.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Services() => await db.Services.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceAge>>> ServiceAges() => await db.ServiceAges.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> Statuses() => await db.Statuses.ToListAsync();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Type>>> Types() => await db.Types.ToListAsync();
        /*[HttpGet("{id}")]
        public async Task<ActionResult<Type>> TypeByID(int id)
        {
            Type type = await db.Types.FirstOrDefaultAsync(x => x.IdType == id);
            if (type == null)
                return NotFound();
            return new ObjectResult(type);
        }*/
    }
}
