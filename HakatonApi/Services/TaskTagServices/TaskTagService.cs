using AutoMapper;
using HakatonApi.DTOs.TaskTagDTO;
using HakatonApi.Repositories.TaskTagRepositories;
using HakatonApi.Services.TaskTagServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Services.TaskTagService
{
    public class TaskTagService : ITaskTagService
    {
        private readonly ITaskTagRepository _taskTagRepository;
        private readonly IMapper _mapper;
        public TaskTagService(ITaskTagRepository repository, IMapper mapper)
        {
            _taskTagRepository = repository;
            _mapper = mapper;
        }

        
        public async Task<List<TaskTagNameDTO>> GetAllTaskTagsAsync()
        {
            var allTaskTagsDB = await _taskTagRepository.GetAllTaskTagsAsync();
            var allTaskTagsDTO = _mapper.Map<List<TaskTagNameDTO>>(allTaskTagsDB);
            return allTaskTagsDTO;
        }

    }
}
