using System.ComponentModel.DataAnnotations;

namespace API.Models
{
public class Book

   {
    [Key]
    public int id_book {get; set;}

    public string description {get; set;}

    public string name {get; set;}


   }
}