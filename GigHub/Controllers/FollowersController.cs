using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowersController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowersController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowerDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followers
                .Any(f => f.FollowerId == userId && f.AtristId == dto.ArtistId))
                return BadRequest("You already follow this artist");

            var follow = new Follow
            {
                AtristId = dto.ArtistId,
                FollowerId = userId
            };
            _context.Followers.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}
