using Nancy.Json;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using ShopTARge22.Core.ServiceInterface;
using System.Net;


namespace ShopTARge22.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<OpenChuckNorrisJokeResultDto> OpenChuckNorrisResult(OpenChuckNorrisJokeResultDto dto)
        {
            string url = $"https://api.chucknorris.io/jokes/random?category={dto.Jokes}";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                ChuckNorrisJokeResponceRootDto chuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisJokeResponceRootDto>(json);

                dto.Categories = chuckNorrisResult.Categories;
                dto.CreatedAt = chuckNorrisResult.CreatedAt;
                dto.Id = chuckNorrisResult.Id;
                dto.UpdatedAt = chuckNorrisResult.UpdatedAt;
                dto.Url = chuckNorrisResult.Url;
                dto.Value = chuckNorrisResult.Value;
                dto.Jokes = chuckNorrisResult.Jokes;
            }
            return null;
        }

    }
}
