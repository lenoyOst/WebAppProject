﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WebApplicationProject_sucks.Models
{
    public class Post
    {
        [Key]public int PostID { get; set; }

        [Required()]
        public string Title { get; set; }

        public DateTime Date { get; set; }


        public int Rating { get; set; }

        public int NumOfRating { get; set; }
        public string Description { get; set; }
        public byte[] Thumbnail { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public virtual ICollection<PostComment> Comments { get; set; }

        //public virtual ICollection<UserToPostRating> AllRatings { get; set; }

        [ForeignKey("ProfessionalPage")]
        public int ProfessionalPageID { get; set; }
        public ProfessionalPage ProfessionalPage { get; set; }

        //It derives from the page categories!
        public virtual ICollection<PostToCategory> Categories { get; set; }

       

    }
}
