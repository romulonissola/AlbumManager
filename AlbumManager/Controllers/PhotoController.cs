using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumManager.Domain.Entities;
using AlbumManager.Domain.Contracts.Service;

namespace AlbumManager.MVC.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _service;

        public PhotoController(IPhotoService service)
        {
            _service = service;
        }

        // GET: Photo
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetPhotosAsync());
        }
    }
}
