using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("agent/[controller]")]
    public class SystemInfoController : ControllerBase
    {
        private readonly DataContext context;

        public SystemInfoController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemInfo>>> GetSystemInfos()
        {
            return await context.SystemInfos.ToListAsync();
            // return new List<SystemInfo>(){new SystemInfo(){Id=1,Timestamp=1,Unit="sds",Value="1"}};
        }
         [HttpGet("{id}")]
        public ActionResult<SystemInfo> GetSystemInfo(int id)
        {
           return context.SystemInfos.Find(id);
        }
    }
}