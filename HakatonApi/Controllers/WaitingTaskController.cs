using AutoMapper;
using HakatonApi.DTOs.WaitingTaskDTO;
using HakatonApi.Helpers;
using HakatonApi.Models;

using HakatonApi.Services.WaitingTaskServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HakatonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaitingTaskController : ControllerBase
    {


        private readonly IWaitingTaskService _service;
        private readonly IUserGeter _userGeter;

        public WaitingTaskController(IWaitingTaskService service, IUserGeter userGeter)
        {
        
            _service = service;
            _userGeter = userGeter;

        }

        [HttpPost("addWaitingTask")]
        public async Task<IActionResult> AddWaitingTask(WaitingTaskFromUserDTO waitingTaskFromUserDto)
        {

           int userId =_userGeter.GetUser(Request.Headers["Authorization"]);
            if (await _service.AddWaitingTask(waitingTaskFromUserDto,userId) != null) return Ok(201);
            else return BadRequest("We can't add waiting task");
        }

        [HttpGet("getCompletedUsersWaitingTasks")]
        public async Task<IEnumerable<WaitingTaskForListDisplayDTO>> GetCompletedUsersWaitingTasks()
        {
            int userId =_userGeter.GetUser(Request.Headers["Authorization"]);
            return await _service.GetCompletedUsersWaitingTask(userId);
        }

        [HttpGet("getActiveUsersWaitingTasks")]
        public async Task<IEnumerable<WaitingTaskForListDisplayDTO>> GetActiveUsersWaitingTasks()
        {
            int userId = _userGeter.GetUser(Request.Headers["Authorization"]);
            return await _service.GetActiveUsersWaitingTask(userId);
        }

        [HttpPost("completeWaitingTask/{waitingTaskName}")]
        public async Task<IActionResult> CompletWaitingTask(string waitingTaskName){
             int userId = _userGeter.GetUser(Request.Headers["Authorization"]);
             await _service.CompleteWaitingTask(waitingTaskName,userId);
             return Ok(102);
        }

        [HttpPost("deleteTask/{waitingTaskName}")]
        public async Task<int> DeleteWaitingTask(string waitingTaskName)
        {
            int userId = _userGeter.GetUser(Request.Headers["Authorization"]);

            return await _service.DeleteWaitingTaskAsync(waitingTaskName, userId);
            //return Ok(102);
        }
    }
}