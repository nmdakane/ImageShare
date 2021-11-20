using ImageShare.Context;
using ImageShare.Models;
using ImageShare.PersonData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ImageShare.ImageShareData
{
    public class ImagesImpl : Iimages
    {
        private DatabaseContext dbContext;
        private IPersonData person;
        
        public ImagesImpl(DatabaseContext a, IPersonData _person)
        {
            dbContext = a;
            person = _person;
        }
        public int deleteImage(string email, string imagename)
        {
            Person user = person.getPerson(email);
            int count = dbContext.Database.ExecuteSqlRaw($"delete from images where person='"+user.id+"' and image_name='"+imagename+"';");
            return count;
        }

        public List<ImageUploaded> GetImages(string email)
        {
            Person user = person.getPerson(email);
            List<ImageUploaded> allImages = dbContext.Images.FromSqlRaw($"select * from images where person='"+user.id+"';").ToList();
            /*ImageUploaded img;
            foreach (var item in allImages)
            {
                byte[] file = System.IO.BinaryReader(item.image)

            }*/
            return allImages;
        }

        public void sendImage(string imagename, string emailtosend)
        {
            throw new NotImplementedException();
        }

        public async void uploadImages(String email,List<IFormFile> images)
        {
            Person user = person.getPerson(email);
            ImageUploaded img;

            if (images.Count > 0)
            {
                foreach (var item in images)
                {
                    img = new ImageUploaded();
                    using (var stream = new MemoryStream())
                    {
                        item.CopyToAsync(stream);
                        img.id = new Guid();
                        img.image = stream.ToArray();
                        img.imageName = System.IO.Path.GetFileName(item.FileName);
                        img.dateCreated = DateTime.Now;
                        img.person =await dbContext.People.FindAsync(user.id);
                    }
                    dbContext.Images.Add(img);
                    
                }
                await dbContext.SaveChangesAsync();

            }
           
            
        }
    }
}
