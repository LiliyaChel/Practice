using kidstrWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace kidstrWebApi.Controllers
{
    //Add data and authentication
    public partial class KidStrController : Controller
    {
        //Authentication
        [HttpPost]
        public async Task<ActionResult<int>> Authent([FromBody] User user)
        {
            if (user == null)
            {
                return -2;
            }
            User realuser = await db.Users.FirstOrDefaultAsync(x => (x.Login == user.Login)&&(x.Password==user.Password));
            if (realuser == null)
                return -1;
            Funcs.Logs.Login(realuser.Login);
            if (realuser.Root)
                return 1;
            else
                return 0;
        }

        //Add data
        //AddServs
        [HttpPost]
        public async Task<ActionResult<int>> AddAServ([FromBody] AddServ data)
        {
            if (data == null)
            {
                return -2;
            }
            Funcs.Logs.AddLog(data.Current, "add", "AddServ");
            db.AddServs.Add(data);
            await db.SaveChangesAsync();
            return data.IdAdd;
        }

        //AddServOrdrs
        [HttpPost]
        public async Task<ActionResult<int>> AddAServOrdr([FromBody] AddServOrdr data)
        {
            if (data == null)
            {
                return -2;
            }
            db.AddServOrdrs.Add(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Ages
        [HttpPost]
        public async Task<ActionResult<int>> AddAge([FromBody] Age data)
        {
            if (data == null)
            {
                return -2;
            }
            db.Ages.Add(data);
            await db.SaveChangesAsync();
            return data.IdGroup;
        }

        //Days
        [HttpPost]
        public async Task<ActionResult<int>> AddDay([FromBody] Day data)
        {
            if (data == null)
            {
                return -2;
            }
            db.Days.Add(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Directions
        [HttpPost]
        public async Task<ActionResult<int>> AddDirection([FromBody] Direction data)
        {
            if (data == null)
            {
                return -2;
            }
            Funcs.Logs.AddLog(data.Current, "add", "Direction");
            db.Directions.Add(data);
            await db.SaveChangesAsync();
            return data.IdDir;
        }

        //Employees
        [HttpPost]
        public async Task<ActionResult<int>> AddEmployee([FromBody] Employee data)
        {
            if (data == null)
            {
                return -2;
            }
            Funcs.Logs.AddLog(data.Current, "add", "Employee");
            db.Employees.Add(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Guides
        [HttpPost]
        public async Task<ActionResult<int>> AddGuide([FromBody] Guide data)
        {
            if (data == null)
            {
                return -2;
            }
            db.Guides.Add(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Ordrs
        [HttpPost]
        public async Task<ActionResult<int>> AddOrdr([FromBody] Ordr data)
        {
            if (data == null)
            {
                return -2;
            }
            Funcs.Logs.AddLog(data.Current, "add", "Ordr");
            db.Ordrs.Add(data);
            await db.SaveChangesAsync();
            return data.IdOrdr;
        }

        //Prices
        [HttpPost]
        public async Task<ActionResult<int>> AddPrice([FromBody] Price data)
        {
            if (data == null)
            {
                return -2;
            }
            db.Prices.Add(data);
            await db.SaveChangesAsync();
            return data.IdPrice;
        }

        //Services
        [HttpPost]
        public async Task<ActionResult<int>> AddService([FromBody] Service data)
        {
            if (data == null)
            {
                return -2;
            }
            Funcs.Logs.AddLog(data.Current, "add", "Service");
            db.Services.Add(data);
            await db.SaveChangesAsync();
            return data.IdServ;
        }

        //ServiceAges
        [HttpPost]
        public async Task<ActionResult<int>> AddServiceAge([FromBody] ServiceAge data)
        {
            if (data == null)
            {
                return -2;
            }
            db.ServiceAges.Add(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Statuses
        [HttpPost]
        public async Task<ActionResult<int>> AddStatus([FromBody] Status data)
        {
            if (data == null)
            {
                return -2;
            }
            db.Statuses.Add(data);
            await db.SaveChangesAsync();
            return data.IdStat;
        }

        //Types
        [HttpPost]
        public async Task<ActionResult<int>> AddType([FromBody] Models.Type data)
        {
            if (data == null)
            {
                return -2;
            }
            Funcs.Logs.AddLog(data.Current, "add", "Type");
            db.Types.Add(data);
            await db.SaveChangesAsync();
            return data.IdType;
        }

    }
}
