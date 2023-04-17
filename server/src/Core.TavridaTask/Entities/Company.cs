namespace Core.TavridaTask.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    
    public bool BinarySign { get; set; }

    public ICollection<CompanyBranch> CompanyBranches { get; set; } = null!;
}