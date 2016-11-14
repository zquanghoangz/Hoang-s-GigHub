using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [System.Web.Http.Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == dto.ArtistId))
            {
                return BadRequest("The following is already exists.");
            }

            var followArtist = new Following
            {
                FolloweeId = dto.ArtistId,
                FollowerId = userId
            };

            _context.Followings.Add(followArtist);
            _context.SaveChanges();

            return Ok();
        }
    }
}