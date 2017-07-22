using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blogging.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        //public string ShortDescription { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        //public string UserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }

        public IList<int> TagIds { get; set; }

        [ForeignKey("TagIds")]
        public virtual IList<Tag> Tags { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IList<PostTagMapping> PostTagMapping { get; set; }
    }

  

   

}