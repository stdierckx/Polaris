namespace Polaris.Api.Models;

public class Points
{
    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int Score { get; set; }
}