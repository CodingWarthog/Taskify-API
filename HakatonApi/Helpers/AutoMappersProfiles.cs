using AutoMapper;
using HakatonApi.DTOs.AuthDTO;
using HakatonApi.DTOs.GlobalTaskDTO;
using HakatonApi.DTOs.LocationDTO;
using HakatonApi.DTOs.TaskTagDTO;
using HakatonApi.DTOs.WaitingTaskDTO;
using HakatonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakatonApi.Helpers
{
    public class AutoMappersProfiles : Profile
    {
        public AutoMappersProfiles()
        {
            CreateMap<UserForRegisterDTO, User>();
            CreateMap<UserForLoginDTO, User>();
            CreateMap<WaitingTaskForListDisplayDTO, WaitingTask>();
            CreateMap<WaitingTaskFromUserDTO, WaitingTask>();

            CreateMap<Location, LocationFromMapDTO>()
                .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.lat, opt => opt.MapFrom(src => src.Latitude))
                .ForMember(dest => dest.lon, opt => opt.MapFrom(src => src.Longtitude));        

            CreateMap<TaskTag, TaskTagNameDTO>()
                .ForMember(dest => dest.TaskTagName, opt => opt.MapFrom(src => src.TagName));

            CreateMap<WaitingTaskLocation, WaitingTaskInRangeAlertDTO>()
               .ForMember(dest => dest.DateAdded, opt => opt.MapFrom(src => src.WaitingTask.DateAdded))
               .ForMember(dest => dest.WaitingTaskName, opt => opt.MapFrom(src => src.WaitingTask.Name))
               .ForMember(dest => dest.Target, opt => opt.MapFrom(src => src.WaitingTask.Target))
               .ForMember(dest => dest.DistanceWhenAlert, opt => opt.MapFrom(src => src.WaitingTask.Distance))
               .ForMember(dest => dest.DateEnd, opt => opt.MapFrom(src => src.WaitingTask.DateEnd))
               .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))
               .ForMember(dest => dest.LocationType, opt => opt.MapFrom(src => src.Location.Type))
               .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.Longtitude))
               .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Latitude));

            CreateMap<GlobalTaskTag, GlobalTaskToDisplayDTO>()
                .ForMember(dest => dest.GlobalTaskName, opt => opt.MapFrom(src => src.GlobalTask.GlobalTaskName))
                .ForMember(dest => dest.Longtitude, opt => opt.MapFrom(src => src.GlobalTask.Longtitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.GlobalTask.Latitude))
                .ForMember(dest => dest.GlobalTaskDescription, opt => opt.MapFrom(src => src.GlobalTask.GlobalTaskDescription))
                .ForMember(dest => dest.GlobalTaskDate, opt => opt.MapFrom(src => src.GlobalTask.GlobalTaskDate))
                .ForMember(dest => dest.GlobalTagName, opt => opt.MapFrom(src => src.GlobalTag.GlobalTagName));

            CreateMap<GlobalTaskToDisplayDTO, GlobalTaskToAlertDTO>();
        }
    }
}
