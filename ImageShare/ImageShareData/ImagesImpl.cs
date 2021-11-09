using ImageShare.Context;
using ImageShare.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.ImageShareData
{
    public class ImagesImpl : Iimages
    {
        private DatabaseContext dbContext;
        
        public ImagesImpl(DatabaseContext a)
        {
            dbContext = a;
        }
        public void deleteImage(ImageUploaded image)
        {
            dbContext.Images.Remove(image);
        }

        public List<ImageUploaded> GetImages()
        {
            List<ImageUploaded> allImages = dbContext.Images.ToList();
            return allImages;
        }

        public void sendImage(ImageUploaded image)
        {
            throw new NotImplementedException();
        }

        public async void uploadImages(Guid id,List<IFormFile> images)
        {

            ImageUploaded img;
            foreach (var item in images)
            {
                img = new ImageUploaded();
                if (item.Length > 0) {

                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        img.id = new Guid();
                        img.image = stream.ToArray();
                        img.imageName = stream.ToString();
                        img.dateCreated = DateTime.Now;
                        img.person = dbContext.People.Find(id);
                    }
                    dbContext.Images.Add(img);
                    dbContext.SaveChanges();
                }
               
            }
           
            
        }
    }
}
