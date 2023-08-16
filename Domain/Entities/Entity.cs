namespace Domain.Entities;

public class Entity
{
    public string Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    protected Entity() 
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}
