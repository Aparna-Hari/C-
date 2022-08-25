#pragma warning disable CS8618
namespace ViewModelFun.Models;
public class User
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    //constructor
    public User(string first, string last)
    {
        FirstName = first;
        LastName  = last;
    }

    public User(string first)
    {
        FirstName = first;
    }

}