using ArtGallery.CJ.WEB.Areas.Manage.Models;
using ArtGallery.CJ.WEB.Areas.Manage.ViewModels;
using ArtGallery.CJ.WEB.Infrastructure.Domain;
using ArtGallery.CJ.WEB.Infrastructure.Domain.Model;
using ArtGallery.CJ.WEB.ViewModels.Artworks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArtGallery.CJ.WEB.Areas.Manage.Controllers
{
    [Area("manage")]
    public class ArtsController : Controller
    {
        private readonly ArtDBContext _context;

        public ArtsController(ArtDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet,Route("manage/Arts")]
        public IActionResult Index(int pageIndex = 1,
                                    int pageSize = 5,
                                    string sortBy = "",
                                    string sortOrder = "asc",
                                    string keyword = "")
        {
            IQueryable<Artwork> allArtworks = _context.Artworks.AsQueryable();
            Paged<Artwork> Artworks = new Paged<Artwork>();

            if (!string.IsNullOrEmpty(keyword))
            {
                allArtworks = allArtworks.Where(f => f.Title.Contains(keyword) || f.Content.Contains(keyword));
            }
            Artworks.Items = allArtworks.ToList();
            var queryCount = allArtworks.Count();
            var skip = pageSize * (pageIndex - 1);

            long pageCount = (long)Math.Ceiling((decimal)(queryCount / pageSize));

            if (sortBy.ToLower() == "brand" && sortOrder.ToLower() == "asc")
            {
                Artworks.Items = allArtworks.OrderBy(e => e.Title).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "firstname" && sortOrder.ToLower() == "desc")
            {
                Artworks.Items = allArtworks.OrderByDescending(e => e.Title).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "asc")
            {
                Artworks.Items = allArtworks.OrderBy(e => e.Medium).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "lastname" && sortOrder.ToLower() == "desc")
            {
                Artworks.Items = allArtworks.OrderByDescending(e => e.Medium).Skip(skip).Take(pageSize).ToList();
            }

            else if (sortBy.ToLower() == "price" && sortOrder.ToLower() == "asc")
            {
                Artworks.Items = allArtworks.OrderBy(e => e.Year).Skip(skip).Take(pageSize).ToList();
            }
            else
            {
                Artworks.Items = allArtworks.OrderByDescending(e => e.Year).Skip(skip).Take(pageSize).ToList();
            }


            var result = new ArtworkSearchViewModel();
            result.Artworks = new Paged<ArtViewModel>();
            result.Artworks.Keyword = keyword;
            result.Artworks.PageCount = pageCount;
            result.Artworks.PageIndex = pageIndex;
            result.Artworks.PageSize = pageSize;
            result.Artworks.QueryCount = queryCount;

            result.Artworks.Items = new List<ArtViewModel>();

            foreach (var artwork in Artworks.Items)
            {
                result.Artworks.Items.Add(new ArtViewModel()
                {
                  ArtistID = artwork.ArtistID,
                  ArtworkID = artwork.ArtworkID,
                  Content = artwork.Content,
                  Medium = artwork.Medium,
                  Title = artwork.Title,
                  Year = artwork.Year
                });
            }


            return View(result);
        }
        [HttpGet("manage/arts/AddArtworks")]
        public IActionResult AddArtworks()
        {
            return View();
        }


        [HttpPost, Route("~/Create")]
        public IActionResult Create(ArtViewModel model)
        {
            Artwork artwork = new Artwork()
            {
                ArtistID = Guid.NewGuid(),
                ArtworkID = Guid.NewGuid(),
                Content = model.Content,
                Medium = model.Medium,
                Title = model.Title,
                Year = model.Year
            };
            _context.Artworks.Add(artwork);
            _context.SaveChanges();
            return Redirect("/manage/arts");
        }


        [HttpGet("manage/arts/update/{id}")]
        public IActionResult Update(Guid? id)
        {
            Artwork artwork = _context.Artworks.FirstOrDefault(p => p.ArtworkID == id);

            if (artwork == null)
            {
                //TODO : error
            }

            return View(new UpdateViewModel()
            {
                ArtworkId = artwork.ArtworkID,
                Title = artwork.Title,
                Content = artwork.Content,
                Medium = artwork.Medium,
                Year = artwork.Year
            });
        }

        [HttpPost("/manage/arts/update")]
        public IActionResult Update(UpdateViewModel model)
        {
            Artwork artwork = _context.Artworks.FirstOrDefault(p => p.ArtworkID == model.ArtworkId);

            if (artwork != null)
            {

                artwork.ArtworkID = model.ArtworkId;
                artwork.Title = model.Title;
                artwork.Content = model.Content;
                artwork.Medium = model.Medium;
                artwork.Year = model.Year;

                _context.Artworks.Update(artwork);
                _context.SaveChanges();
            }
            else
            {
                
            }

            return RedirectPermanent("/manage/artworks");

        }

        [HttpPost("/manage/arts/delete")]
        public IActionResult Remove(IdViewModel model)
        {
            Artwork artwork = _context.Artworks.FirstOrDefault(p => p.ArtworkID == model.ArtworkId);

            if (artwork != null)
            {
                _context.Artworks.Remove(artwork);
                _context.SaveChanges();
            }

            else
            {
            
            }

            return RedirectPermanent("/manage/arts");

        }
    }
}