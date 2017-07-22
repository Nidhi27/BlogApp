using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogging.Models
{
    public class PostTagMapping
    {
        public int Id { get; set; }

        public int TagId { get; set; }
        public int PostId { get; set; }
        [ForeignKey("PostId")]      
           
        public virtual Post Post { get; set; }

        [ForeignKey("TagId")]

        public virtual Tag Tag { get; set; }
    }
}