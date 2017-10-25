using GigHub.Models;
using GigHub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Following()
        {
            var artists = _context.Followings
                .Select(a => a.Artist)
                .ToList();

            var viewModel = new AtristsViewModel()
            {
                ArtistsToFollow = artists,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View("Artists", viewModel);
        }
    }
}