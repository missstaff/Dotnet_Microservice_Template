using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class AppUser : IdentityUser
    {
        public override string Id { get; set; } = "";
        public string? FirstName { get; set; } = "";
        public string? LastName { get; set; } = "";
        private string _email = "";
        public override string Email
        {
            get => _email;
            set
            {
                _email = value;
                NormalizedEmail = value?.ToUpper();
            }
        }

        public override string NormalizedEmail { get; set; } = "";
        public byte[] ProfilePicture { get; set; } = new byte[0];

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";

    }
}