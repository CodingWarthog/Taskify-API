using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using HakatonApi.DTOs.LocationDTO;
using HakatonApi.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HakatonApi.Repositories.MapRepository
{
    public class MapRepository : IMapRepository
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public MapRepository(IConfiguration configuration, IMapper mapper)
        {
            _mapper = mapper;

            _configuration = configuration;
        }
        public async Task<IEnumerable<Location>> GetLocations(string waitingTaskText, double latitude,double longtitude)
        {
            HttpClient httpClient = new HttpClient();
            List<LocationFromMapDTO> model = null;
            int radius=1000;
            string requestString="https://maps.googleapis.com/maps/api/place/nearbysearch/json?keyword="+waitingTaskText+"&location="+ latitude+","+  longtitude +"&radius="+radius+"&app_id=HeckathonWAW&key=AIzaSyA8negFCBWrBfk0pnYRd7eo4vYuh6Zj2xI";
           System.Console.WriteLine("Request:  "+requestString);
           // string requestString="https://maps.googleapis.com/maps/api/place/nearbysearch/json?keyword=Biedronka&location=  52.246071,21.052415&radius=1000&app_id=HeckathonWAW &key=AIzaSyA8negFCBWrBfk0pnYRd7eo4vYuh6Zj2xI";
            HttpResponseMessage locationsFromMap= await httpClient.GetAsync(requestString);
            locationsFromMap.EnsureSuccessStatusCode();
            string responseBody = await locationsFromMap.Content.ReadAsStringAsync();

            JObject responseJson = JObject.Parse(responseBody);
            JArray jsonArray=JArray.Parse(responseJson["results"].ToString());

           
            List<Location> locations= new List<Location>();
            for(int i=0;i<jsonArray.Count;i++){
                JObject json = JObject.Parse(jsonArray[i].ToString());
                Location location= new Location(){
                    Name=waitingTaskText,
                    Longtitude=json["geometry"]["location"]["lng"]+"" ,
                    Latitude=json["geometry"]["location"]["lat"]+""
                };
                locations.Add(location);
            }
            

            return locations;


        }
    }
}