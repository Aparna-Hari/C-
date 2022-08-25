#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[NotMapped] //Denotes that a property or class should be excluded from database mapping.
public class LoginUser
{
    [Required(ErrorMessage = "is required.")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "is required.")]
    [MinLength(8, ErrorMessage = "must be at least 8 characters.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}