namespace Core.TavridaTask.Models;

public class GetCompanyBranchesByCompanyBinarySignModel
{
    public List<CompanyBranch> CompanyBranches { get; set; } = new();

    public record CompanyBranch(string Name, string CompanyName, bool CompanyBinarySign, int[] AssociatedBranchesIds);
}