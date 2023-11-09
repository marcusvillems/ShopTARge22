using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Models.ChuckNorris;

namespace ShopTARge22.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController(
            IChuckNorrisServices chuckNorrisServices)
        {
            _chuckNorrisServices = chuckNorrisServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            SearchChuckNorrisJokeViewModel model = new();

            return View(model);
        }
        [HttpPost]
        public IActionResult SearchJokes(SearchChuckNorrisJokeViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Jokes", "ChuckNorrisJokes", new { jokes = model.JokeName });
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Jokes(string jokes)
        {
            OpenChuckNorrisJokeResultDto dto = new();

            dto.Jokes = jokes;
            _chuckNorrisServices.OpenChuckNorrisResult(dto);
            ChuckNorrisViewModel vm = new();

            vm.Categories = dto.Categories;
            vm.CreatedAt = dto.CreatedAt;
            vm.Id = dto.Id;
            vm.UpdatedAt = dto.UpdatedAt;
            vm.Url = dto.Url;
            vm.Value = dto.Value;
            vm.Jokes = dto.Jokes;

            return View(vm);
        }
    }
}
