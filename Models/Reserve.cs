
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Reserve 
    {

        [Key]
        public int id {get; set;}
        public int code {get; set;}

        public int book_id {get; set;}

        public int user_id {get; set;}

        public DateTime date_reserve {get; set;}

    }
}