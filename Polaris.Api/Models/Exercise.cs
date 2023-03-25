namespace Polaris.Api.Models;

public class Exercise
{
    public int Id { get; set; }
    public int ExerciseTypeId { get; set; }
    public ExerciseType ExerciseType { get; set; }
    public int Reps { get; set; }
    public int Sets { get; set; }
    public string Notes { get; set; }
    public ICollection<Points> Points { get; set; }
}