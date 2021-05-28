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
    [Route("api/[controller]")]
    public class OnBoardController:ControllerBase
    {
        private readonly DataContext context;

        public OnBoardController(DataContext _context)
        {
            context = _context;
        }
        //THIS IS TO START PUSHING DATA
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SystemInfo>>> GetSystemInfos()
        {
            return await context.SystemInfos.ToListAsync();
            // return new List<SystemInfo>(){new SystemInfo(){Id=1,Timestamp=1,Unit="sds",Value="1"}};
        } 
    }
}