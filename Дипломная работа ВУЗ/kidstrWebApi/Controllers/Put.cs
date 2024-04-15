using kidstrWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace kidstrWebApi.Controllers
{
    //Update data
    public partial class KidStrController : Controller
    {        
        //AddServs
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAServ([FromBody] AddServ data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.AddServs.Any(x => x.IdAdd == data.IdAdd))
            {
                return -1;
            }
            Funcs.Logs.AddLog(data.Current, "update", "AddServ");
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //AddServOrdrs
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAServOrdr([FromBody] AddServOrdr data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.AddServOrdrs.Any(x => x.IdAdd == data.IdAdd && x.IdOrdr == data.IdOrdr))
            {
                return -1;
            }
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Ages
        [HttpPut]
        public async Task<ActionResult<int>> UpdateAge([FromBody] Age data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Ages.Any(x => x.IdGroup == data.IdGroup))
            {
                return -1;
            }
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Directions
        [HttpPut]
        public async Task<ActionResult<int>> UpdateDirection([FromBody] Direction data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Directions.Any(x => x.IdDir == data.IdDir))
            {
                return -1;
            }
            Funcs.Logs.AddLog(data.Current, "update", "Direction");
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Employees
        [HttpPut]
        public async Task<ActionResult<int>> UpdateEmployee([FromBody] Employee data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Employees.Any(x => x.IdEmp == data.IdEmp))
            {
                return -1;
            }
            Funcs.Logs.AddLog(data.Current, "update", "Employee");
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Ordrs
        [HttpPut]
        public async Task<ActionResult<int>> UpdateOrdr([FromBody] Ordr data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Ordrs.Any(x => x.IdOrdr == data.IdOrdr))
            {
                return -1;
            }
            Funcs.Logs.AddLog(data.Current, "update", "Ordr");
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Prices
        [HttpPut]
        public async Task<ActionResult<int>> UpdatePrice([FromBody] Price data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Prices.Any(x => x.IdPrice == data.IdPrice))
            {
                return -1;
            }
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Services
        [HttpPut]
        public async Task<ActionResult<int>> UpdateService([FromBody] Service data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Services.Any(x => x.IdServ == data.IdServ))
            {
                return -1;
            }
            Funcs.Logs.AddLog(data.Current, "update", "Service");
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Statuses
        [HttpPut]
        public async Task<ActionResult<int>> UpdateStatus([FromBody] Status data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Statuses.Any(x => x.IdStat == data.IdStat))
            {
                return -1;
            }
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Types
        [HttpPut]
        public async Task<ActionResult<int>> UpdateType([FromBody] Models.Type data)
        {
            if (data == null)
            {
                return -2;
            }
            if (!db.Types.Any(x => x.IdType == data.IdType))
            {
                return -1;
            }
            Funcs.Logs.AddLog(data.Current, "update", "Type");
            db.Update(data);
            await db.SaveChangesAsync();
            return 0;
        }
    }
}
