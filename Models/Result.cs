using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{//start of namespace
    public class Result
    {//start of class
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public int EventId { get; set; }
        public double FinishTime { get; set; } 
        public int Position { get; set; }
    }//end of class
}//end of namespace

