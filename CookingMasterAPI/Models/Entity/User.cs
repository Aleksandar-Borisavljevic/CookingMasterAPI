using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookingMasterAPI.Models.Entity
{
    public class User
    {
        #region Properties
        [Key]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; } = new byte[32];

        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[32];

        [Column(TypeName = "nvarchar(1000)")]
        public string? VerificationToken { get; set; }

        public DateTime? VerifiedAt { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string? PasswordResetToken { get; set; }

        public DateTime? ResetTokenExpires { get; set; }
        #endregion
    }
}
