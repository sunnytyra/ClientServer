using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
   [Route("master/[controller]")]
    public class SystemInfoController : ControllerBase
    {
        private readonly DataContext context;
        private readonly IHttpClientFactory clientFactory;

        public SystemInfoController(DataContext _context,IHttpClientFactory _clientFactory)
        {
            context = _context;
            clientFactory = _clientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterInfo>>> GetSystemInfos()
        {
            try{
            IEnumerable<SystemInfo> infos = null;
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:5002/agent/systeminfo");
            var client = clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                infos = await JsonSerializer.DeserializeAsync
                    <IEnumerable<SystemInfo>>(responseStream);
            }
            return null;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
            return null;

            }
            //return await context.MasterInfos.ToListAsync();
            // return new List<SystemInfo>(){new SystemInfo(){Id=1,Timestamp=1,Unit="sds",Value="1"}};
        }
    }
}