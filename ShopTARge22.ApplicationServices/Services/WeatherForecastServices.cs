using Nancy.Json;
using ShopTARge22.Core.Dto.WeatherDtos;
using ShopTARge22.Core.ServiceInterface;
using System.Net;

namespace ShopTARge22.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string idOpenWeather = "e647c34e4d90740d22ee2a55ba0f33e2";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City},&units=metric&appid={idOpenWeather}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                idOpenWeather = json;

                WeatherResponseRootDto weatherResult = new JavaScriptSerializer().Deserialize<WeatherResponseRootDto>(json);

                dto.City = weatherResult.Name;
                dto.Temp = weatherResult.Main.Temp;
                dto.FeelsLike = weatherResult.Main.Feels_like;
                dto.Humitity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.WindSpeed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weather[0].Description;
            }


            return null;
        }
    }
}
