using SportLife.Context.Enums;
using SportLife.Context.Models;

namespace SportLife.Services.Models
{
    public class ExerciseRequest
    {
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
