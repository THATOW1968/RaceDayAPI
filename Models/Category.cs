using System.ComponentModel.DataAnnotations;

namespace RaceDayAPI.Models
{//start of namespace
    public class Category
    {//start of class
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } 
        public int EventId { get; set; }
    }//end of class
}//end of namespace

