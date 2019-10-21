using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;

namespace HakatonApi.Repositories.MapRepository
{
    public interface IMapRepository
    {
         Task<IEnumerable<Location>> GetLocations(string waitingTaskText,double latitude , double  longtitude);
    
    }
}