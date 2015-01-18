using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [MinLength(5)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime ModifiedDate { get; set; }

        [Required]
        public int State { get; set; }

    }
}