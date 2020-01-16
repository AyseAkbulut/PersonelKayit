using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelKayit.Models
{
    public class Personel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Geçersiz Mail Adresi.")]
        public string email { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string phone { get; set; }
    }
}