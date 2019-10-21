using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Repositories.WaitingTaskRepository
{
    public interface IWaitingTaskRepository
    {
         Task<WaitingTask> AddWaitingTask(WaitingTask  waitingTask);
         Task<IEnumerable<WaitingTask>> GetUsersWaitingTask(int iduser);     
         Task<IEnumerable<WaitingTask>> GetCompletedUsersWaitingTask(int iduser);     
         Task<IEnumerable<WaitingTask>> GetActiveUsersWaitingTask(int iduser);
        Task<WaitingTask> CompleteWaitingTask(string waitingTaskName,int userId);
        Task<int> SetWaitingTaskAsDeletedAsync(string waitingTaskName, int userId);
        Task<bool> Contain(string waitingTaskName,int userId);
    }
}