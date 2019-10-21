using AutoMapper;
using HakatonApi.DTOs.AuthDTO;
using HakatonApi.DTOs.GlobalTaskDTO;
using HakatonApi.DTOs.LocationDTO;
using HakatonApi.Helpers;
using HakatonApi.Models;
using HakatonApi.Repositories.GPSRepositories;
using HakatonApi.Services.GlobalTaskServices;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Services.GPSServices
{
    public class GPSService : IGPSService
    {
        private readonly IUserGeter _userGeter;
        private readonly IGPSRepository _gpsRepository;
        private readonly IGlobalTaskService _globalTaskService;
        private readonly IMapper _mapper;
        public GPSService(IGPSRepository gpsRepository, IMapper mapper,
                            IGlobalTaskService globalTaskService, IUserGeter userGeter)
        {
            _gpsRepository = gpsRepository;
            _mapper = mapper;
            _userGeter = userGeter;
            _globalTaskService = globalTaskService;
        }

        public async Task<AllTasksInRangeAlertDTO> UserGPSActualizationAsync(GPSUserActualizationDTO gpsUserActualizationDTO, int userId)
        {
            //51.716126, 19.727151

            //51.717033, 19.727564
            //90m

            //51.717916, 19.727872
            //210

            //51.717265, 19.723420
            //290
            
            //double distanceToPoint = distance(51.716126, 19.727151, 51.717265, 19.723420, 'm');
            
            List<WaitingTaskInRangeAlertDTO> locationsToReturn = new List<WaitingTaskInRangeAlertDTO>();
            
            var userWaitingTasks = await _gpsRepository.GetUserTaskLocationsAsync(userId);
            if (userWaitingTasks.Count > 0) {
                for (int i = 0; i < userWaitingTasks.Count; i++)
                {
                    double[] locationPoint = { double.Parse(userWaitingTasks[i].Location.Latitude, CultureInfo.InvariantCulture),
                                           double.Parse(userWaitingTasks[i].Location.Longtitude, CultureInfo.InvariantCulture) };

                    double distanceToPoint = distance(gpsUserActualizationDTO.Latitude, gpsUserActualizationDTO.Longtitude,
                                                        locationPoint[0], locationPoint[1], 'm');

                    if (distanceToPoint <= userWaitingTasks[i].WaitingTask.Distance)
                    {
                        WaitingTaskInRangeAlertDTO taskToAlert = _mapper.Map<WaitingTaskInRangeAlertDTO>(userWaitingTasks[i]);
                        taskToAlert.DistanceFromUserToLocation = distanceToPoint;

                        locationsToReturn.Add(taskToAlert);
                    }
                }
            }
            //List<GlobalTaskToDisplayDTO>> GetGlobalTaskForTodayAsync()

            List<GlobalTaskToAlertDTO> globalTasksToAlert = new List<GlobalTaskToAlertDTO>();
            List<GlobalTaskToDisplayDTO> globalTasksForToday = await _globalTaskService.GetGlobalTaskForTodayAsync();

            if (globalTasksForToday.Count>0)
            {
                for (int i = 0; i < globalTasksForToday.Count; i++)
                {
                    double[] locationPoint = { double.Parse(globalTasksForToday[i].Latitude, CultureInfo.InvariantCulture),
                                           double.Parse(globalTasksForToday[i].Longtitude, CultureInfo.InvariantCulture) };

                    double distanceToPoint = distance(gpsUserActualizationDTO.Latitude, gpsUserActualizationDTO.Longtitude,
                                                        locationPoint[0], locationPoint[1], 'm');

                    if (distanceToPoint <= 1000)
                    {
                        GlobalTaskToAlertDTO globalTaskToAlert = _mapper.Map<GlobalTaskToAlertDTO>(globalTasksForToday[i]);
                        globalTaskToAlert.DistanceFromUser = distanceToPoint;

                        globalTasksToAlert.Add(globalTaskToAlert);
                    }
                }
            }

            AllTasksInRangeAlertDTO toRet = new AllTasksInRangeAlertDTO();
            toRet.globalTasksInRange = globalTasksToAlert;
            toRet.userWaitingTaskInRange = locationsToReturn;

            return toRet;
        }


        private double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }
            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                else if (unit == 'm')
                {
                    dist = dist * 1.609344 * 1000;
                }
                return (dist);
            }
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts decimal degrees to radians             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        //::  This function converts radians to decimal degrees             :::
        //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
        private double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }
    }
}
