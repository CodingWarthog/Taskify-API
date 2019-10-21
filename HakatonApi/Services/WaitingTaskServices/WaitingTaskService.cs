using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HakatonApi.DTOs.WaitingTaskDTO;
using HakatonApi.Models;
using HakatonApi.Repositories.MapRepository;
using HakatonApi.Repositories.WaitingTaskRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using HakatonApi.Repositories;
using HakatonApi.Repositories.WaitingTaskLocationRepository;
using System.Globalization;

namespace HakatonApi.Services.WaitingTaskServices
{
    public class WaitingTaskService : IWaitingTaskService
    {
        private readonly IWaitingTaskRepository _repo;
        private readonly IMapService _mapService;
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepo;
        private readonly IWaitingTaskLocationRepository _wtlRepo;
        public WaitingTaskService(IWaitingTaskRepository repo, ILocationRepository locationRepo, IWaitingTaskLocationRepository wtlRepo, IMapService mapService, IMapper mapper)
        {
            _wtlRepo = wtlRepo;
            _locationRepo = locationRepo;
            _repo = repo;
            _mapService = mapService;
            _mapper = mapper;

        }

        public async Task<WaitingTask> AddWaitingTask(WaitingTaskFromUserDTO waitingTaskFromUserDto,int userId)
        {
            if(!_repo.Contain(waitingTaskFromUserDto.Name,userId).Result){
             
            WaitingTask waitingTask = new WaitingTask()
            {

                DateAdded = DateTime.Now,
                Name = waitingTaskFromUserDto.Name,
                Target = waitingTaskFromUserDto.Target,
                UserId = userId,
                IsCompleted = false,
                IsSinglePoint = false,
                Distance = 500,
                DateDone = null,
                DateEnd = waitingTaskFromUserDto.DateEnd,
                IsDeleted= false

                
                
            };
            double longtitude=double.Parse(waitingTaskFromUserDto.Longtitude, CultureInfo.InvariantCulture);
            double latitude=double.Parse(waitingTaskFromUserDto.Latitude, CultureInfo.InvariantCulture);

            var locations = await _mapService.GetLocations(waitingTaskFromUserDto.Name,latitude,longtitude);
            List<Location> responseLocationsWithId = new List<Location>();
            foreach (Location location in locations)
            {
                Location addLocationResponse = await _locationRepo.AddLocation(location);
                responseLocationsWithId.Add(addLocationResponse);
            }

        

            WaitingTask responseWaitingTask = await _repo.AddWaitingTask(waitingTask);

            List<WaitingTaskLocation> intersectionList = new List<WaitingTaskLocation>();

            foreach (Location loc in responseLocationsWithId)
            {
                WaitingTaskLocation wtl = new WaitingTaskLocation()
                {
                    LocationId = loc.IdLocation,
                    WaitingTaskId = responseWaitingTask.IdWaitingTask
                };
                intersectionList.Add(wtl);
            }

            foreach (WaitingTaskLocation wtl in intersectionList)
            {
                await _wtlRepo.AddWaitingTaskLocation(wtl);
            }
              return responseWaitingTask;}

          else{
              return null;
          }

        }

        public async Task<List<WaitingTaskForListDisplayDTO>> GetUsersWaitingTask(int userId)
        {
            var waitingTasksList = await _repo.GetUsersWaitingTask(userId);

            return _mapper.Map<List<WaitingTaskForListDisplayDTO>>(waitingTasksList);
        }
        public async Task<List<WaitingTaskForListDisplayDTO>> GetCompletedUsersWaitingTask(int userId)
        {
            var waitingTasksList = await _repo.GetCompletedUsersWaitingTask(userId);

            return _mapper.Map<List<WaitingTaskForListDisplayDTO>>(waitingTasksList);
        }
        public async Task<List<WaitingTaskForListDisplayDTO>> GetActiveUsersWaitingTask(int userId)
        {
            var waitingTasksList = await _repo.GetActiveUsersWaitingTask(userId);

            return _mapper.Map<List<WaitingTaskForListDisplayDTO>>(waitingTasksList);
        }

        public async Task<WaitingTask> CompleteWaitingTask(string waitingTaskName, int userId)
        {
            return await _repo.CompleteWaitingTask(waitingTaskName, userId);

        }

        public async Task<int> DeleteWaitingTaskAsync(string waitingTaskName, int userId)
        {
            return await _repo.SetWaitingTaskAsDeletedAsync(waitingTaskName, userId);
        }
    }
}