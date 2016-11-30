using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Controllers.Api;

namespace GigHub.Controllers
{
    public class FollowsController : Controller
    {
        private ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Follows
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(a => a.Followee)
                .ToList();

            var viewModel = new FollowingsViewModel()
            {
                Artists = artists,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Artists I'm Following"
            };
            return View(viewModel);
        }
    }
}