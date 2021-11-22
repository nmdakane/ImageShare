using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.Models
{
    public class ImageUploaded
    {
        [Key]
        [Column("Image_id")]
        public Guid id {get; set;}

       
        [ForeignKey("Person")]
        public Person person { get; set; }

        [Required]
        [Column("Image_name")]
        public String imageName { set; get; }


        [Required]
        [Column("Image")]
        public byte[] image { set; get; }

        [Required]
        [Column("image_geolocation")]
        public string geolocation { set; get; }

        [Required]
        [Column("image_tag")]
        public string tag { set; get; }

        [Required]
        [Column("image_capturedBy")]
        public string captured_by { set; get; }

        [Required]
        [Column("Date_captured")]
        public DateTime dateCreated { set; get; }
    }
}
