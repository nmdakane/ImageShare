using ImageShare.ImageShareData;
using ImageShare.Models;
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
        [Route("add/{email}")]
        public IActionResult AddImages(string email, List<IFormFile> images)
        {
            image.uploadImages(email,images);
            return Ok("Image successfully uploaded");

        }

        [HttpGet]
        [Route("get/{email}")]
        public IActionResult getImages(string email)
        {
            List<ImageUploaded> list = image.GetImages(email);
            return Ok(list);

        }

        [HttpDelete]
        [Route("delete/{email}/{name}")]
        public IActionResult deleteImage(string email, string name)
        {
            int count = image.deleteImage(email, name);           
            return Ok(count + " Image suucessfully deleted");

        }
    }
}
