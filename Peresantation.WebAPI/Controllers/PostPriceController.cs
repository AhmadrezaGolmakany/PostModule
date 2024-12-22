using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostModule.Application.Contract.PostApplication;
using PostModule.Application.Contract.PostPriceApplication;

namespace Peresantation.WebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostPriceController : ControllerBase
    {
       private readonly IPostPriceApplication _postPriceApplication;

        public PostPriceController(IPostPriceApplication postPriceApplication)
        {
            _postPriceApplication = postPriceApplication;
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAllForPost(int id)
        {
            var model = _postPriceApplication.GetAllForPost(id);
            return Ok(model);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult Get(int id) 
        {
            var model = _postPriceApplication.GetForEdite(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePostPrice model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = _postPriceApplication.Create(model);

            if (res.Success) return Ok();
            return BadRequest(new {message = res.Message});

        }

        [HttpPatch("[action]")]
        public IActionResult Edite([FromBody] EditPostPrice model )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res = _postPriceApplication.Edite(model);

            if (res.Success) return NoContent();
            return BadRequest(new { message = res.Message });

        }
    }
}
