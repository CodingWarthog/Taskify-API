using HakatonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Repositories.GPSRepositories
{
    public interface IGPSRepository
    {
        Task<List<WaitingTaskLocation>> GetUserTaskLocationsAsync(int idUser);
    }
}
