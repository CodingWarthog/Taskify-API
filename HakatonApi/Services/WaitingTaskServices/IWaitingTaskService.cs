using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.DTOs.WaitingTaskDTO;
using HakatonApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Services.WaitingTaskServices
{
    public interface IWaitingTaskService
    {
        Task<WaitingTask> AddWaitingTask(WaitingTaskFromUserDTO waitingTaskFromUserDTO,int userId);
        Task<List<WaitingTaskForListDisplayDTO>> GetUsersWaitingTask(int userId);
        Task<List<WaitingTaskForListDisplayDTO>> GetCompletedUsersWaitingTask(int userId);
        Task<List<WaitingTaskForListDisplayDTO>> GetActiveUsersWaitingTask(int userId);
        Task<WaitingTask> CompleteWaitingTask(string waitingTaskName,int UserId);
        Task<int> DeleteWaitingTaskAsync(string waitingTaskName, int userId);
    }
}