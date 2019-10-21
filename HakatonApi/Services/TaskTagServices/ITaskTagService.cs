using HakatonApi.DTOs.TaskTagDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Services.TaskTagServices
{
    public interface ITaskTagService
    {
        Task<List<TaskTagNameDTO>> GetAllTaskTagsAsync();
    }
}
