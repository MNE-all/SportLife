namespace SportLife.Context.Models
{
    public class ExerciseStep
    {
        public Guid Id { get; set; }
        public Guid ExerciseId { get; set; }
        public string Description { get; set; } = null!;
        public int Step { get; set; } = 0;
    }
}
