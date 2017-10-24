using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowerDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings
                .Any(f => f.FollowerId == userId && f.ArtistId == dto.ArtistId))
                return BadRequest("You already follow this artist");

            var following = new Following
            {
                ArtistId = dto.ArtistId,
                FollowerId = userId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
