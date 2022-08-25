#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;


public class Dish{
    [Key]
    public int DishId {get; set;}

    [Required]
    [MinLength(2, ErrorMessage ="must be more than 2 characters")]
    public string Name {get; set;}

    [Required]
    [MinLength(2, ErrorMessage ="Must be more than 2 characters")]
    public string Chef {get; set;}

    [Required]
    public int? Tastiness {get; set;}

    [Required]
    [Range(2,2000 ,ErrorMessage ="Please enter calories between 2 and 2000")]
    public int? Calories {get; set;}

    public string? Description {get; set;}

    public DateTime CreatedAt {get; set;}=DateTime.Now;

    public DateTime UpdatedAt {get; set;}=DateTime.Now;
}