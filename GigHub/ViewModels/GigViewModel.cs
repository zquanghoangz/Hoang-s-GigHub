using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class GigViewModel
    {
        public IEnumerable<Gig> Gigs { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}