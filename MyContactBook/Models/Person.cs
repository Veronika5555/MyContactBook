using System;
using System.ComponentModel.DataAnnotations;

namespace MyContactBook.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20)]
        [RegularExpression(@"[a-zA-ZáÁčČďĎéÉěĚíÍňŇóÓřŘšŠťŤúÚůŮýÝžŽ]+$", ErrorMessage = "Name isn't valid.")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        [RegularExpression(@"[a-zA-ZáÁčČďĎéÉěĚíÍňŇóÓřŘšŠťŤúÚůŮýÝžŽ]+$", ErrorMessage = "Surname isn't valid.")]
        [StringLength(50, MinimumLength = 3)]
        public String Surname { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("[1-9]{1}[0-9]{8}", ErrorMessage = "Phone number isn't valid.")]
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email isn't valid.")]
        public String Email { get; set; }
    }
}
