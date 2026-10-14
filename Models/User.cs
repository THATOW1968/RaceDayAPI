using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{//start of namespace
    public class User
    {//start of class
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Role { get; set; } 
    }//end of class
}//end of namespace

