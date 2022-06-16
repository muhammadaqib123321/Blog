using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class AddCategory
    {
        [Key]
        public int catid { get; set; }
        public string catname { get; set; }
        [NotMapped]
        public Boolean isSelect { get; set; }
    }
}