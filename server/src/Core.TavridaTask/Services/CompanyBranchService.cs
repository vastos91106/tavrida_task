using Core.TavridaTask.Entities;
using Core.TavridaTask.Interfaces.Repositories;
using Core.TavridaTask.Interfaces.Services;
using Core.TavridaTask.Models;

namespace Core.TavridaTask.Services;

public class CompanyBranchService : ICompanyBranchService
{
    private readonly IGenericRepository<CompanyBranch> _companyBranchRepository;

    public CompanyBranchService(IGenericRepository<CompanyBranch> companyBranchRepository)
    {
        this._companyBranchRepository = companyBranchRepository;
    }

    public async Task<GetCompanyBranchesByCompanyBinarySignModel> GetByCompanyBinarySignAsync(
        CancellationToken cancellationToken)
    {
        GetCompanyBranchesByCompanyBinarySignModel result = new();

        var branches = await _companyBranchRepository.AllWhereAsync(cancellationToken,
            navigationPropertyPath: branch => branch.Company);
       
        foreach (var branch in branches)
        {
            var company = branch.Company;

            var selectedBranchesIds = company.BinarySign
                ? branches.Select((companyBranch => companyBranch.Id)).ToList()
                : branches.Where(companyBranch => companyBranch.CompanyId == branch.CompanyId)
                    .Select(companyBranch => companyBranch.Id);
        
            result.CompanyBranches.Add(new(branch.Name, company.Name, company.BinarySign,
                selectedBranchesIds.ToArray()));
        }

        return result;
    }
}