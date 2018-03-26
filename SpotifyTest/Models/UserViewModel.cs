using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System;

namespace SpotifyTest.Models
{
    public abstract class BaseEntity
    {
        // EMPTY!!!
    }
    public class RegUser : BaseEntity
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage="Full Name must be at least 2 characters!")]
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        public string FullName { get;set; }

        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(2, ErrorMessage="Username must be at least 2 characters!")]
        public string Username { get;set; }

        [Required]
        public DateTime Birthdate { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get;set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get;set; }
    }
    public class LoginUser : BaseEntity
    {
        [Required]
        [EmailAddress]
        public string Email { get;set; }

        [Required]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        [DataType(DataType.Password)]
        public string Password { get;set; }
    }
}
// MIGRATION NOTES: 
// dotnet ef migrations add FirstMigration
// dotnet ef database update