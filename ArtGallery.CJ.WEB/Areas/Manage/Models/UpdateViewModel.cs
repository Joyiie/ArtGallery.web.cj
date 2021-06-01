using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.CJ.WEB.Areas.Manage.Models
{
    public class UpdateViewModel
    {
        public Guid? ArtworkId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Medium { get; set; }
        public string Year { get; set; }
    }
}
