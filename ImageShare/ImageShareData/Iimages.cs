using ImageShare.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ImageShare.ImageShareData
{
    public interface Iimages
    {
        public void uploadImages(string email,List<IFormFile> images);
        List<ImageUploaded> GetImages(string email);

        int deleteImage(string email, string imagename);

        void sendImage(string imagename, string emailtosend);
    }
}
