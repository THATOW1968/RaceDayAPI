using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{//start of namespace
    public class Enrolment
    {//start of class
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; } 
        public int EventId { get; set; }
        public int CategoryId { get; set; }
    }//end of class
}//end of namespace

