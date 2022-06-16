using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Addtag
    {
        [Key]
        public int tagid { get; set; }
        public string tagname { get; set; }

        [NotMapped]
        public bool isSelected { get; set; }
    }
}