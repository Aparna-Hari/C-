#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class GuestList   // Many to many "Through"/"Join" table
{
    [Key]
    public int GuestListId {get; set;}

    
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    /**********************************************************************
    Relationship properties below
    Foreign Keys: id of a different (foreign) model
    Navigation Props:
        data type is a related model
        MUST use the .Include for the nav prop data to be included via a SQL JOIN statement
    **********************************************************************/

//test it by removing
    public int UserId {get; set;}
    public User? User {get; set;}

    [Required]
    public int WeddingId {get; set;}
    public Wedding? Wedding {get; set;}
    
}