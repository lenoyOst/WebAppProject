﻿using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web;

namespace WebApplicationProject_sucks.Models
{
    public class Clip : Item
    {
        [Key] public int ClipID { get; set; }
        public string ClipTitle { get; set; }
        public byte[] ClipData { get; set; }
        public string[] Size { get; set; }
        public string[] Location { get; set; }
        
        
        public void Display() { }
    }
}
