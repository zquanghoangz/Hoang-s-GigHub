using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class FollowingsViewModel
    {
        public List<ApplicationUser> Artists { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}