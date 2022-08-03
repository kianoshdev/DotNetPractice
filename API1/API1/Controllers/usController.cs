using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API1.Data;
using API1.Entitis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usController : Controller
    {
        public DBCotext DB { get; }

        public usController(DBCotext dB)
        {
            DB = dB;
        }
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(ModelUser user)
        {
            if (await IsExist(user.ID)) return BadRequest("UserName is taken");
            User obj = new User(){BirthDay = user.BirthDay, ID = user.ID, Age = user.GetAge()};
            DB.users.Add(obj);
            await DB.SaveChangesAsync();
            return obj;
        }

        [HttpPost("update")]
        public async Task<ActionResult<User>> Update(ModelUser user)
        {
            if (!await IsExist(user.ID)) return BadRequest("UserName is not taken");
            var obj = DB.users.Where(i => i.ID == user.ID).Single();
            obj.ID = user.ID;
            obj.BirthDay = user.BirthDay;
            obj.Age = user.GetAge();
            await DB.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> IsExist(int id)
        {
            return await DB.users.AnyAsync(i => i.ID == id);
        }
    }
}
