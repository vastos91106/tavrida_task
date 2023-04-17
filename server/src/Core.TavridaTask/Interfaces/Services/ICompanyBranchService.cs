using Core.TavridaTask.Models;

namespace Core.TavridaTask.Interfaces.Services;

public interface ICompanyBranchService
{
    Task<GetCompanyBranchesByCompanyBinarySignModel> GetByCompanyBinarySignAsync(CancellationToken cancellationToken);
}