using System;
using System.Collections.Generic;
using System.Linq;
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

        public ImagesController(AgileEngineService agileEngineService)
        {
            _agileEngineService = agileEngineService;
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
