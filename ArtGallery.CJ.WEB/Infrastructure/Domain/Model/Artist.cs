using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.CJ.WEB.Infrastructure.Domain.Model
{
    public class Artist
    {
         
        public Guid? ArtistID { get; set; }
        public string Name { get; set; }
        public string BirthPlace { get; set; }
        public string Age { get; set; }
        public string StyleOfWork { get; set; }
    
}
}
