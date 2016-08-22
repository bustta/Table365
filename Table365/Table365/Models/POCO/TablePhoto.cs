using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Table365.Models.POCO
{
    public class TablePhoto
    {
        [DisplayName("ID")]
        [Key]
        [Required]
        public Guid Id { get; set; }

        [DisplayName("User")]
        [Required]
        public User User { get; set; }

        [DisplayName("Description")]
        [StringLength(256)]
        [MaxLength(256, ErrorMessage = "Max length 256 letters")]
        public string Description { get; set; }

        [DisplayName("Location")]
        public string Location { get; set; }

        [DisplayName("PostTime")]
        [Required]
        public DateTime PostTime { get; set; }

        [DisplayName("Photo")]
        [Required]
        public byte[] Photo { get; set; }

    }
}