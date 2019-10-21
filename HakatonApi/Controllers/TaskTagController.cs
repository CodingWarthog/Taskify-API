using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HakatonApi.DTOs.TaskTagDTO;
using HakatonApi.Services.TaskTagServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTagController : ControllerBase
    {
        private readonly ITaskTagService _taskTagService;

        public TaskTagController(ITaskTagService taskTagService)
        {
            _taskTagService = taskTagService;
        }

        [HttpGet("allTaskTags")]
        public async Task<List<TaskTagNameDTO>> GetAllTags()
        {
            return await _taskTagService.GetAllTaskTagsAsync();

        }

    }
}