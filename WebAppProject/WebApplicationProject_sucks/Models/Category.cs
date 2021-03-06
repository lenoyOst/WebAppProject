﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class Category
    {
        [Key] public string Name { get; set; }
        public virtual ICollection<ProfessionalToCategory> Professionals { get; set; }
        public virtual ICollection<ProfessionalToCategory> ProfessionalPages { get; set; }
        public virtual ICollection<RoomToCategory> Rooms { get; set; }

        public virtual ICollection<UserToCategory> Users { get; set; }
        public virtual ICollection<PostToCategory> Posts { get; set; }

    }
}