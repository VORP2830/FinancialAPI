namespace Financial.Domain.Filter
{
    public class MovementFilter
    {
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CreatedUntil { get; set; } = DateTime.UtcNow.AddDays(30);
        public string? Description { get; set; } = string.Empty;
    }
}