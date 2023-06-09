
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    
    {
            [Key]
            public int id {get; set;}
            public string name { get; set; }

            public string facultad {get; set;}

    }
}