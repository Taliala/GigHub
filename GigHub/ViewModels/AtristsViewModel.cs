using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.ViewModels
{
    public class AtristsViewModel
    {        
        public List<ApplicationUser> ArtistsToFollow { get; set; }
        public bool ShowActions { get; set; }
    }
}