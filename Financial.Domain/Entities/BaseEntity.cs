namespace Financial.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public bool Active { get; protected set; }
        public DateTime ModifiedAt  { get; set; }
        public DateTime CreatedAt  { get; set; }
        public void SetActive(bool active)
        {
            Active = active;
        }
    }
}