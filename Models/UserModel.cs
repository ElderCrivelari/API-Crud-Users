using System.ComponentModel.DataAnnotations;

namespace CRUDUsersAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

    }
}
