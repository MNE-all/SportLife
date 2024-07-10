namespace SportLife.Services.Models
{
    public class ExerciseStepRequest
    {
        public Guid ExerciseId { get; set; }
        public string Description { get; set; } = null!;
    }
}
