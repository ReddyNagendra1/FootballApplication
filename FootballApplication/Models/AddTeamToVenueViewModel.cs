using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballApplication.Models;

namespace FootballApplication.Models
{
    public class AddTeamToVenueViewModel
    {
        public VenueDto Venue { get; set; }
        public IEnumerable<TeamDto> Teams { get; set; }
    }
}