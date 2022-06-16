using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Create
    {
        [Key]
        public int blogid { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string metadescription { get; set; }
        public string metatitle { get; set; }
        public string imagealt { get; set; }
        public string blogdescription { get; set; }

        public string bFilePath { get; set; }
    
        public string bFileName { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper ImageFile { get; set; }


        //publisher image
        public string pFilePath { get; set; }

        public string pFileName { get; set; }
        [NotMapped]
        public HttpPostedFileWrapper pImageFile { get; set; }
        //publisher image

        [Display(Name = "AddCategory")]
        public virtual int catid { get; set; }

        [ForeignKey("catid")]
        public virtual AddCategory AddCategory { get; set; }

        [ForeignKey("blogid")]
        public virtual List<Maptag> Maptags { get; set; }

        //[NotMapped]
        //public virtual IList<Addtag> tags { get; set; }
        [NotMapped]
        public string tagss { get; set; }

        [NotMapped]
        public List<int> tags { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}