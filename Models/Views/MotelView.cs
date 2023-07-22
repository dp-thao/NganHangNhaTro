using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace NganHangNhaTro.Models.Views
{
    public class MotelView
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được bỏ trống")]
        public string title { get; set; }

        public string description { get; set; }

        [Required]
        public string detail { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string price { get; set; }

        public IFormFile image { get; set; }

        // Trạng thái
        [Required]
        public bool status { get; set; }
    }
}