﻿using System;
using System.Collections.Generic;
namespace WebApplicationProject_sucks
{
    public class Comment
    {

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public int CommentID { get; set; }

        public List<Item> Content { get; set; }

        public Comment(string userName)
        {
            this.UserName = userName;

        }

    }
}