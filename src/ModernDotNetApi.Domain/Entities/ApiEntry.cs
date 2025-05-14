namespace ModernDotNetApi.Domain.Entities;
public class ApiEntry
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}