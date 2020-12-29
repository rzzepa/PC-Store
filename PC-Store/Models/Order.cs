using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        public string User { get; set; }

        public List<OrderDetail> OrderLines{ get; set; }

        [Required(ErrorMessage ="Wpisz swoje imię")]
        [Display(Name ="Imię")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Wpisz swoje Nazwisko")]
        [Display(Name = "Nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Wpisz swoj adres")]
        [Display(Name = "Adres")]
        [StringLength(100)]
        public string AddressLine{ get; set; }

        [Required(ErrorMessage = "Wpisz swój kod pocztowy")]
        [Display(Name = "Kod pocztowy")]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Display(Name = "Kraj")]
        public string Country { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
        ErrorMessage = "Wpisany E-mail ma zły format")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }

        [Required(ErrorMessage = "Wybierz sposób płatności")]
        public string Payment { get; set; }

        public string StatusOrder { get; set; }

        [Required]
        public bool Regulations { get; set; }
    }
}
