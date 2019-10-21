using HakatonApi.DTOs.TaskTagDTO;
using HakatonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Repositories.TaskTagRepositories
{
    public interface ITaskTagRepository
    {
        Task<List<TaskTag>> GetAllTaskTagsAsync();
    }
}
