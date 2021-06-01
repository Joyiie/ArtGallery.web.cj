using ArtGallery.CJ.WEB.Infrastructure.Domain;
using ArtGallery.CJ.WEB.Infrastructure.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.CJ.WEB.ViewModels.Artworks
{
    public class ArtworkSearchViewModel
    {
        public Paged<ArtViewModel> Artworks { get; set; }
    }

    public class ArtViewModel : Artwork
    {
    }
}
