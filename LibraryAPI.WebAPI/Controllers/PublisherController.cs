using LibraryAPI.Application.Services.ReadServices.AuthorReadService;
using LibraryAPI.Application.Services.ReadServices.PublisherReadService;
using LibraryAPI.Application.Services.WriteServices.AuthorWriteServices;
using LibraryAPI.Application.Services.WriteServices.PublisherWriteServices;
using LibraryAPI.Domain.Entities.BookEntites;
using LibraryAPI.Dtos.Resources.AuthorResources;
using LibraryAPI.Dtos.Resources.PublisherResources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherReadService _publisherReadService;
        private readonly IPublisherWriteService _publisherWriteService;
        public PublisherController(IPublisherWriteService publisherWriteService, IPublisherReadService publisherReadService)
        {
            
            _publisherWriteService = publisherWriteService;
            _publisherReadService = publisherReadService;
        }

        [HttpPost("addPublisher")]
        public async Task<IActionResult> AddPublisher(AddPublisherDto addPublisherDto)
        {
            var res = await _publisherWriteService.AddPublisher(addPublisherDto);
            return Ok(res);

        }
        [HttpPost("deletePublisher")]
        public async Task<IActionResult> DeletePublisher(int id)
        {
            var res = await _publisherWriteService.DeletePublisher(id);
            return Ok(res);
        }
        [HttpPost("updatePublisher")]
        public async Task<IActionResult> UpdatePublisher(UpdatePublisherDto publisher)
        {
            var res = await _publisherWriteService.UpdatePublisher(publisher);
            return Ok(res);
        }

        [HttpGet("getAllPublisher")]
        public async Task<IActionResult> GetAllPublisher()
        {
            var res = await  _publisherReadService.GetAllPublisher();
            return Ok(res);
        }
        [HttpGet("getAllPublisherView")]
        public async Task<IActionResult> GetAllPublisherView()
        {
            var res = await _publisherReadService.GetAllPublisherView();
            return Ok(res);
        }
        [HttpGet("getPublisherById")]
        public async Task<IActionResult> GetPublisherById(int id)
        {
            var res = await _publisherReadService.GetPublisherById(id);
            return Ok(res);
        }
        [HttpGet("getPublisherByName")]
        public async Task<IActionResult> GetPublisherByName(string name)
        {
            var res = await _publisherReadService.GetPublisherByName(name);
            return Ok(res);
        }

    }
}
