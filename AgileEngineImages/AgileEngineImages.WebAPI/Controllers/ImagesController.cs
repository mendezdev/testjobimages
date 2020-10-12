using System.Collections.Generic;
using System.Threading.Tasks;
using AgileEngiteImages.ApplicationServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgileEngineImages.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        private readonly AgileEngineService _agileEngineService;
        private readonly ImageService _imageService;

        public ImagesController(AgileEngineService agileEngineService, ImageService imageService)
        {
            _agileEngineService = agileEngineService;
            _imageService = imageService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]int page)
        {
            var images = await _agileEngineService.GetImages(page);
            return Ok(images);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var image = await _agileEngineService.GetImageByIdAsync(id);
            return Ok(image);
        }

        [HttpGet]
        [Route("search/{searchTerm}")]
        public async Task<IActionResult> Search(string searchTerm)
        {
            return Ok(await _imageService.Search(searchTerm));
        }

    }
}
