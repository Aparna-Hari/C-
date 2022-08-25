#pragma warning disable CS8618
namespace DojoSurveyWithModel.Models;

using System.ComponentModel.DataAnnotations;

public class Survey{
    [Required(ErrorMessage ="Name is required")]
    [MinLength(2,ErrorMessage ="Name should be no less than 2 characters")]
    public string Name { get; set; }

    [Required]
    public string Location { get; set; } 

    [Required]
    public string Language { get; set; }

    
    
    public string? Comment { get; set; }


}