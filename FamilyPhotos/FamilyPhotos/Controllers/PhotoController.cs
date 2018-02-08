using FamilyPhotos.Models;
using FamilyPhotos.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Controllers
{
    public class PhotoController : Controller
    {

        public PhotoRepository repository { get; }
        public PhotoController(PhotoRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;
        }



        public IActionResult Index()
        {

            var pics = repository.GetAllPhotos();

            return View(pics);

        }

        public FileContentResult GetImage(int photoId)
        {
            var pic = repository.GetPicture(photoId: photoId);

            if (pic == null || pic.Picture == null)
                return null;

            return File(pic.Picture, pic.ContentType);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new PhotoModel());
        }

        [HttpPost]
        public IActionResult Create(PhotoModel model)
        {
            if (model.PictureFromBrowser == null || model.PictureFromBrowser.Length == 0)
            {
                return View(model);
            }

            //fogadó bájt tömb
            model.Picture = new byte[model.PictureFromBrowser.Length];
            using (var stream = model.PictureFromBrowser.OpenReadStream())
            {
                //ehelyett buffer+ciklus
                stream.Read(model.Picture, 0, (int)model.PictureFromBrowser.Length);

            }
            model.ContentType = model.PictureFromBrowser.ContentType;

            repository.AddPhoto(model);

            return View(model);
        }

    }
}
