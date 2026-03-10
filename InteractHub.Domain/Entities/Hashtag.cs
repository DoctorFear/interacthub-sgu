namespace InteractHub.Domain.Entities;

public class Hashtag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;  // ví dụ: "dotnet" (không có #)

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}