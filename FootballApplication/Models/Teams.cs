using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace FootballApplication.Models
{
    public class Teams
    {
        [Key]
        public int TeamID { get; set; }

        public string TeamName { get; set; }

        public string TeamBio { get; set; }
        //A team has many players
        public virtual ICollection<Player> Player { get; set; }
        //A team plays in many venues
        public virtual ICollection<Venues> Venues { get; set; }
    }
    public class TeamDto
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string TeamBio { get; set; }
    }

}