using kidstrWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kidstrWebApi.Controllers
{
    //Delete data
    public partial class KidStrController : Controller
    {
        //AddServs
        [HttpDelete("{id}/{user}")]
        public async Task<ActionResult<int>> DeleteAServ(int id, string user)
        {
            AddServ data = db.AddServs.First(x => x.IdAdd == id);
            if (data == null)
            {
                return -1;
            }
            Funcs.Logs.AddLog(user, "delete", "AddServ");
            if (db.AddServOrdrs.Any(x => x.IdAdd == id))
                data.Outdated = true;
            else
                db.AddServs.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //AddServOrdrs
        [HttpDelete("{idS}/{idO}")]
        public async Task<ActionResult<int>> DeleteAServOrdr(int idS, int idO)
        {
            AddServOrdr data = db.AddServOrdrs.First(x => (x.IdAdd == idS && x.IdOrdr == idO));
            if (data == null)
            {
                return -1;
            }
            db.AddServOrdrs.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Ages
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteAge(int id)
        {
            Age data = db.Ages.First(x => x.IdGroup == id);
            if (data == null)
            {
                return -1;
            }
            db.Ages.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Days
        [HttpDelete("{idS}/{idN}")]
        public async Task<ActionResult<int>> DeleteDay(int idS, int idN)
        {
            Day data = db.Days.First(x => (x.IdServ == idS && x.DayNum == idN));
            if (data == null)
            {
                return -1;
            }
            db.Days.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Directions
        [HttpDelete("{id}/{user}")]
        public async Task<ActionResult<int>> DeleteDirection(int id, string user)
        {
            Direction data = db.Directions.First(x => x.IdDir == id);
            if (data == null)
            {
                return -1;
            }
            Funcs.Logs.AddLog(user, "delete", "Direction");
            if (db.Services.Any(x => x.IdDir == id))
                data.Outdated = true;
            else
                db.Directions.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Employees
        [HttpDelete("{id}/{user}")]
        public async Task<ActionResult<int>> DeleteEmployee(string id, string user)
        {
            Employee data = db.Employees.First(x => x.IdEmp == id);
            if (data == null)
            {
                return -1;
            }
            Funcs.Logs.AddLog(user, "delete", "Employee");
            db.Employees.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Guides
        [HttpDelete("{idE}/{idS}")]
        public async Task<ActionResult<int>> DeleteGuide(string idE, int idS)
        {
            Guide data = db.Guides.First(x => (x.IdEmp == idE && x.IdServ == idS));
            if (data == null)
            {
                return -1;
            }
            db.Guides.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Ordrs
        [HttpDelete("{id}/{user}")]
        public async Task<ActionResult<int>> DeleteOrdr(int id, string user)
        {
            Ordr data = db.Ordrs.First(x => x.IdOrdr == id);
            if (data == null)
            {
                return -1;
            }
            Funcs.Logs.AddLog(user, "delete", "Ordr");
            db.Ordrs.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Prices
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeletePrice(int id)
        {
            Price data = db.Prices.First(x => x.IdPrice == id);
            if (data == null)
            {
                return -1;
            }
            if (db.Ordrs.Any(x => x.IdPrice == id))
                data.Outdated = true;
            else
                db.Prices.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Services
        [HttpDelete("{id}/{user}")]
        public async Task<ActionResult<int>> DeleteService(int id, string user)
        {
            Service data = db.Services.First(x => x.IdServ == id);
            if (data == null)
            {
                return -1;
            }
            Funcs.Logs.AddLog(user, "delete", "Service");
            if ((from s in db.Services
                join p in db.Prices on s.IdServ equals p.IdServ
                join o in db.Ordrs on p.IdPrice equals o.IdPrice
                where s.IdServ == id
                select o).Count()>0)
                data.Outdated = true;
            else
                db.Services.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //ServiceAges
        [HttpDelete("{idS}/{idG}")]
        public async Task<ActionResult<int>> DeleteServiceAge(int idS, int idG)
        {
            ServiceAge data = db.ServiceAges.First(x => (x.IdServ == idS && x.IdGroup == idG));
            if (data == null)
            {
                return -1;
            }
            db.ServiceAges.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Statuses
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteStatus(int id)
        {
            Status data = db.Statuses.First(x => x.IdStat == id);
            if (data == null)
            {
                return -1;
            }
            db.Statuses.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }

        //Types
        [HttpDelete("{id}/{user}")]
        public async Task<ActionResult<int>> DeleteType(int id, string user)
        {
            Models.Type data = db.Types.First(x => x.IdType == id);
            if (data == null)
            {
                return -1;
            }
            Funcs.Logs.AddLog(user, "delete", "Type");
            if (db.Services.Any(x => x.IdType == id))
                data.Outdated = true;
            else
                db.Types.Remove(data);
            await db.SaveChangesAsync();
            return 0;
        }
    }
}
