using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mrs.Models
{
    public class UserAccount
    {
        [Key]
        public int IdKorisnika { get; set; }
        [Required(ErrorMessage ="Morate uneti ime korisnika!")]

        public string Ime { get; set; }
        [Required(ErrorMessage = "Morate uneti prezime korisnika!")]

        public string Prezime { get; set; }
        [Required(ErrorMessage = "Morate uneti email korisnika!")]

        public string Email { get; set; }

        public string Grad { get; set; }

        public string Adresa { get; set; }

        [Required(ErrorMessage = "Morate uneti lozinku!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage ="Morate potvrditi lozinku!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string BrojTelefona { get; set; }

    }
}
