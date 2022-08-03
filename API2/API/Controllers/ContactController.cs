using Microsoft.AspNetCore.Mvc;
using API2.Entities;
using API2.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly DBCotext dBCotext;
        public ContactController(DBCotext dBCotext)
        {
            this.dBCotext = dBCotext;

        }

        [HttpPost("register")]
        public async Task<ActionResult<Cotacts>> SetNumber(Cotacts cotacts)
        {
            if(await IsExist(cotacts.ID)) return BadRequest("Id is Valide");
            Regex regex = new Regex("[0-9]{8}");
            if(! regex.IsMatch(cotacts.Number.ToString())) return BadRequest("Pattern is not true");
            await dBCotext.Contacts.AddAsync(cotacts);
            await dBCotext.SaveChangesAsync();
            return cotacts;
        }

        public async Task<bool> IsExist(int cotacts)
        {
            return await dBCotext.Contacts.AnyAsync( i => i.ID == cotacts);
        }
    }
}