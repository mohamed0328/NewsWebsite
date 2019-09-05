using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SomaliaNews.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(2, ErrorMessage ="2 characters minimum")]
        [MaxLength(25, ErrorMessage = "25 characters maximum")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Context is required")]
        [MinLength(2, ErrorMessage = "2 characters minimum")]
        [MaxLength(5000, ErrorMessage = "25 characters minimum")]
        public string NewsContext { get; set; }

        public DateTime NewsDate { get; set; } = DateTime.Now;

        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Side is required")]
        [MinLength(2, ErrorMessage = "2 characters minimum")]
        [MaxLength(10, ErrorMessage = "25 characters minimum")]

        public string Side { get; set; }

        [Required(ErrorMessage = "News Reporter is required")]
        [MinLength(2, ErrorMessage = "2 characters minimu")]
        [MaxLength(25, ErrorMessage = "50 characters maximum")]
        public string NewsReporter { get; set; }
       
    }

}