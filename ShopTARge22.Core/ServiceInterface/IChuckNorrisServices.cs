using ShopTARge22.Core.Dto.ChuckNorrisDtos;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<OpenChuckNorrisJokeResultDto> OpenChuckNorrisResult(OpenChuckNorrisJokeResultDto dto);
    }
}
