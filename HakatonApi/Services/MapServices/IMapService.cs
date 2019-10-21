using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;

namespace HakatonApi.Services
{
    public interface IMapService
    {
       Task<IEnumerable<Location>> GetLocations(string waitingTaskText,double latitude , double  longtitude);
    }
}