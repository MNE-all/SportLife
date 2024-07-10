using SportLife.Context.Enums;

namespace SportLife.Context.Models
{
    /// <summary>
    /// Упражнение
    /// </summary>
    public class Exercise
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        /// <summary>
        /// Тип упражнения
        /// </summary>
        public List<ExerciseType> ExerciseTypes { get; set; } = new List<ExerciseType>();
        /// <summary>
        /// Минимальное время отдыха после подхода (секунд)
        /// </summary>
        public int RestAfterApproachMinSecond { get; set; }
        /// <summary>
        /// Максимальное время отдыха после подхода (секунд)
        /// </summary>
        public int RestAfterApproachMaxSecond { get; set; }
        /// <summary>
        /// Время восстановления после тренировки (дней)
        /// </summary>
        public int RestAfterTrainingDays { get; set; }

        public List<MuscleType> MuscleTypes { get; set; } = new List<MuscleType>();
        public List<ExerciseStep> ExerciseSteps { get; set; } = new();

    }
}
