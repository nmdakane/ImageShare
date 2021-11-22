using ImageShare.Context;
using ImageShare.ImageShareData;
using ImageShare.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ImageShare.PersonData;
using System.IO;

namespace ImageShare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private Iimages image;
        DatabaseContext database;
        private IPersonData iperson;

        public ImagesController(Iimages a, DatabaseContext db, IPersonData x)
        {
            image = a;
            database = db;
            iperson = x;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddImages(ImageUploaded imagedata)
        {
            
            ImageUploaded image = new ImageUploaded();

            image.image = imagedata.image;
            image.id = Guid.NewGuid();
            image.imageName = imagedata.imageName;
            image.captured_by = imagedata.captured_by;
            image.geolocation = imagedata.geolocation;
            image.tag = imagedata.tag;
            image.dateCreated = imagedata.dateCreated;
            image.person = database.People.Where(x=>x.email.Equals(imagedata.person.email)).FirstOrDefault();

            if (image != null) {
                database.Images.Add(image);
                database.SaveChangesAsync();
                return Ok("Image successfully uploaded");
            }
            return NoContent();

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

        [HttpPost]
        [Route("update")]
        public IActionResult updateImage(ImageUploaded image)
        {
            ImageUploaded pic = new ImageUploaded();
            pic.id = image.id;
            pic.imageName = image.imageName;
            pic.image = image.image;
            pic.tag = image.tag;
            pic.geolocation = image.geolocation;
            pic.captured_by = image.captured_by;
            pic.dateCreated = image.dateCreated;
            pic.person = image.person;
            database.Images.Update(pic);
            database.SaveChangesAsync();
            return Ok("Image suucessfully Updated");

        }

        [HttpPost]
        [Route("share")]
        public IActionResult shareImage(Shared image)
        {
            Person per = database.People.Where(s=>s.email.Equals(image.email)).FirstOrDefault();
            Shared pic = new Shared();
            pic.user_id = image.person.id;
            pic.image_id = image.image.id;
            pic.id = Guid.NewGuid();
            pic.email = image.email;
            if (pic != null) {
                
                database.Shared.Add(pic);
                database.SaveChangesAsync();
                return Ok("Image shared uploaded");
            }
            return NotFound();
            

        }

        [HttpGet]
        [Route("shared/get/{email}")]
        public IActionResult sharedImages(string email)
        {
            Person per = iperson.getPerson(email);
            List<Shared> pics = database.Shared.Where(a=>a.person.Equals(per)).ToList();
            List<ImageUploaded> images = new List<ImageUploaded>();
            foreach (var pic in pics)
            {
                images.Add(database.Images.Where(e => e.id.Equals(pic.image_id)).FirstOrDefault());
            }
            return Ok(images);
           

        }

        [HttpGet]
        [Route("tome/get/{email}")]
        public IActionResult sharedtome(string email)
        {
            List<Shared> pics = database.Shared.Where(a => a.email.Equals(email)).ToList();
            List<ImageUploaded> images = new List<ImageUploaded>();
            foreach (var pic in pics) {
                images.Add(database.Images.Where(e => e.id.Equals(pic.image_id)).FirstOrDefault());
            }
            return Ok(images);

        }

        [HttpGet]
        [Route("search/{data}")]
        public IActionResult searchImage(string data)
        {
            List<ImageUploaded> searchImage = database.Images.Where(e => e.geolocation.Contains(data) || e.imageName.Contains(data) ||
                e.tag.Contains(data) || e.captured_by.Contains(data)
            ).ToList();
            
            return Ok(searchImage);

        }
    }
}
