using System.Threading.Tasks;
using HakatonApi.Models;

namespace HakatonApi.Repositories.WaitingTaskLocationRepository
{
    public interface IWaitingTaskLocationRepository
    {
        Task<WaitingTaskLocation> AddWaitingTaskLocationInLoop(WaitingTaskLocation waitingTaskLocation);
        Task<WaitingTaskLocation> AddWaitingTaskLocation(WaitingTaskLocation waitingTaskLocation);
        void SaveChanges();

    }
}