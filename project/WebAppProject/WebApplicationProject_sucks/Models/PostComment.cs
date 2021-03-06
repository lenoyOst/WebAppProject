﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class PostComment
    {
        public PostComment() { }
        public PostComment(int commentID, int postID, string commentContent, string commentCreator, DateTime date)
        {
            this.PostCommentID = commentID;
            this.PostID = postID;
            this.PostCommentContent = commentContent;
            this.UserName = commentCreator;
            this.Date = date;
        }

        [Key] public int PostCommentID { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set;}
        public Post Post { get; set; }

        [Required(ErrorMessage = "You cannot post an empty comment...")]
        public string PostCommentContent { get; set; }

        [ForeignKey("User")]
        public string UserName { get; set; }
        public User User { get; set; }

        public DateTime Date { get; set; }

    }
}