using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BeautyBazaar.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(100)]
        public string City { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(100)]
        public string Country { get; set; } = string.Empty;
    }
}