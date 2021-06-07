using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductApp.Model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Prix { get; set; }
        //public string ImagePath { get; set; }

        //[NotMapped]
        //public string ImageSrc { get; set; }
        //[NotMapped]
        //public IFormFile ImageFile { get; set; }
    }
}
