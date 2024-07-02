using FootballApplication.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace FootballApplication.Models
{
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPosition { get; set; }

        //A Player can only play in one team
        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public virtual Teams Team { get; set; }

    }

    public class PlayerDto
    {
        public int PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string PlayerPosition { get; set; }
        public int TeamID { get; set; } 
        public string TeamName { get; set; }

    }
}