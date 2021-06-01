using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.CJ.WEB.Infrastructure.Domain.Model
{
    public class Artwork
    {
        public Guid? ArtworkID { get; set; }
        public Guid? ArtistID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Content { get; set; }
        public string Medium { get; set; }
    }
}
