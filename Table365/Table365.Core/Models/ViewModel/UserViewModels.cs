using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Table365.Core.Models.POCO;

namespace Table365.Core.Models.ViewModel
{
    public class UserViewModels
    {
        public UserViewModels()
        {
            Id = Guid.NewGuid();
        }

        [DisplayName("ID")]
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Account")]
        [Required]
        [StringLength(50)]
        [MinLength(5, ErrorMessage = "Min length 5")]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        public string Account { get; set; }

        [DisplayName("Password")]
        [Required]
        [StringLength(200)]
        [MinLength(6, ErrorMessage = "Min length 6")]
        [MaxLength(200, ErrorMessage = "Max length 200")]
        public string Password { get; set; }

        [DisplayName("Name")]
        [Required]
        [StringLength(50)]
        [MinLength(2, ErrorMessage = "Min length 2")]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        public string Name { get; set; }

        [DisplayName("e-Mail")]
        [Required]
        public string Email { get; set; }

        [DisplayName("RegisterTime")]
        public DateTime RegisterTime { get; set; }

        [DisplayName("LoginTime")]
        public DateTime LoginTime { get; set; }

        [DisplayName("ImageFile")]
        //public byte[] ProfilePhoto { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public ICollection<TablePhoto> TablePhotos { get; set; }
    }
}