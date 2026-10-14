using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{//start of namespace
    public class Event
    {//start of class
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public double Distance { get; set; }
        public string EventType { get; set; } 
    }//end of class
}//end of namespace
