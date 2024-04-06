using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Dto
{
    public class UserDto
    {
        [Required]
        public string UserName { get; private set; } //login
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public UserRole Role { get; private set; }
        [Required]
        public string PasswordHash { get; private set; }
        

        public UserDto(string userName, string email, UserRole role, string passwordHash)
        {
            
            UserName = userName;
            Email = email;
            Role = role;
            PasswordHash = passwordHash;
        }

    }
}
