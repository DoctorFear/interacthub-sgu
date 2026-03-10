namespace InteractHub.Domain.ValueObjects;

public record FullName(string FirstName, string LastName)
{
    public string DisplayName => $"{FirstName} {LastName}".Trim();
}