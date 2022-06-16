using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Maptag
    {
        [Key]
        public int maptagid { get; set; }

        [Display(Name = "Addtag")]
        public virtual int tagid { get; set; }

        [ForeignKey("tagid")]
        public virtual Addtag Addtag { get; set; }

        [Display(Name = "Blog")]
        public virtual int blogid { get; set; }

        [ForeignKey("blogid")]
        public virtual Create Blog { get; set; }

    }
}