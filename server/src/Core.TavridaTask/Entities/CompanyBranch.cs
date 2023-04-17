namespace Core.TavridaTask.Entities;

public class CompanyBranch : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int CompanyId { get; set; }

    public Company Company { get; set; } = null!;
}