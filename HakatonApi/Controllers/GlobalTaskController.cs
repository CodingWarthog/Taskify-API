using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HakatonApi.DTOs.GlobalTaskDTO;
using HakatonApi.Services.GlobalTaskServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalTaskController : ControllerBase
    {
        private readonly IGlobalTaskService _service;

        public GlobalTaskController(IGlobalTaskService service)
        {
            _service = service;
        }

        [HttpGet("getGlobalTask")]
        public async Task<List<GlobalTaskToDisplayDTO>> GetGlobalTaskForToday()
        {
            return await _service.GetGlobalTaskForTodayAsync();
        }
    }
}