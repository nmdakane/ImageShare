using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImageShare.Models
{
    public class Shared
    {
        [Key]
        [Column("id")]
        public Guid id { get; set; }
        
        public Guid user_id { get; set; }
        [ForeignKey("user_id")]
        [Column("user_id")]
        public Person person { get; set; }

        public Guid image_id { get; set; }
        [ForeignKey("image_id")]
        [Column("image_id")]
        public ImageUploaded image { get; set; }

        [Column("share_with")]
        public string email{ get; set; }
    }
}
