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
        public void uploadImages(Guid id,List<IFormFile> images);
        List<ImageUploaded> GetImages();

        void deleteImage(ImageUploaded image);

        void sendImage(ImageUploaded image);
    }
}
