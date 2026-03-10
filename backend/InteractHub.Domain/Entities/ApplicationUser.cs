using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace InteractHub.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string ProfilePictureUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastActiveAt { get; set; }

    // Navigation properties (sẽ config relationship trong DbContext sau)
    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
    public virtual ICollection<Friendship> FriendshipsAsRequester { get; set; } = new List<Friendship>();
    public virtual ICollection<Friendship> FriendshipsAsRecipient { get; set; } = new List<Friendship>();
    public virtual ICollection<Story> Stories { get; set; } = new List<Story>();
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    public virtual ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();
}