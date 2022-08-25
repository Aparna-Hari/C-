#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltExam.Models;


public class EnthusiastList
{
    [Key]
    public int EnthusiastListId {get; set;}

    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;

    /**********************************************************************
    Relationship properties below
    Foreign Keys: id of a different (foreign) model
    Navigation Props:
        data type is a related model
        MUST use the .Include for the nav prop data to be included via a SQL JOIN statement
    **********************************************************************/


    public int UserId {get; set;}
    public User? User {get; set;}


    public int HobbyId {get; set;}
    public Hobby? Hobby {get; set;}
}