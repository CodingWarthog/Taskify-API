using System.Collections.Generic;
using System.Threading.Tasks;
using HakatonApi.Models;
using HakatonApi.Repositories.MapRepository;

namespace HakatonApi.Services
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        public MapService(IMapRepository mapRepository)
        {
            _mapRepository = mapRepository;

        }
        public async Task<IEnumerable<Location>> GetLocations(string waitingTaskText,double latitude, double  longtitude)
        {
            return await _mapRepository.GetLocations(waitingTaskText, latitude,longtitude); 
        }
    }
}