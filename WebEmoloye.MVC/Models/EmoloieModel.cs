using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebEmoloye.MVC.Models
{
    public class EmoloieModel
    {
        [Range(1000, 10000)]
        [Display(Name = "Emoloie ID")]
        public int EmoloieId { get; set; }
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }
        [Required]
        [Display(Name = "Date Of Start")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOS { get; set; }
        [Display(Name = "Address")]
        public string Adress { get; set; }
        [Display(Name = "Telephon Number")]
        public string Telephon { get; set; }
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Work Section")]
        public string Section { get; set; }
        [Display(Name = "Position")]
        public string Position { get; set; }
    }
}
