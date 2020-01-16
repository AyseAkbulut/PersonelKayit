using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelKayit.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Giriniz.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}