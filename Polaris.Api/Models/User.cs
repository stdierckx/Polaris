namespace Polaris.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public ICollection<Points> Points { get; set; } 
}