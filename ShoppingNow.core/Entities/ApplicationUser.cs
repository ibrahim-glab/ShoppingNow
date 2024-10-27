using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingNow.core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public override string? UserName { get => base.Email; set => base.Email = value; }
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }
        public DateOnly Createdat { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
