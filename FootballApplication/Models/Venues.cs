﻿using FootballApplication.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballApplication.Models
{
    public class Venues
    {
        [Key]
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenueLocation { get; set; }

        //Many teams plays in venues
        public virtual ICollection<Teams> Teams { get; set; }
    }
    public class VenueDto
    {
        public VenueDto()
        {
            Teams = new List<TeamDto>();
        }
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public string VenueLocation { get; set; }

        public ICollection<TeamDto> Teams { get; set; }
    }
}