using ImageShare.ImageShareData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private Iimages image;

        public ImagesController(Iimages a)
        {
            image = a;
        }

        [HttpPut]
        [Route("add")]
        public IActionResult AddImages(Guid id, List<IFormFile> images)
        {
            image.uploadImages(id,images);
            return Created(HttpContext.Request.Scheme + "//" + HttpContext.Request.Host + HttpContext.Request.Path + "/" , image);

        }
    }
}
