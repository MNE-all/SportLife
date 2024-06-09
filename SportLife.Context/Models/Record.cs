namespace SportLife.Context.Models
{
    public class Record
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Amount { get; set; }
        /// <summary>
        /// Килограммы
        /// </summary>
        public float Weight { get; set; } = 0;

        public User? User { get; set; }
        public Guid UserId { get; set; }
    }
}
