using Core.TavridaTask.Interfaces.Services;
using Core.TavridaTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.TavridaTask.Controllers;

public class CompanyBranchController : BaseController
{
    private readonly ICompanyBranchService _companyBranchService;

    public CompanyBranchController(ICompanyBranchService companyBranchService)
    {
        _companyBranchService = companyBranchService;
    }

    [HttpGet("by-company-branch-sign")]
    public async Task<GetCompanyBranchesByCompanyBinarySignModel> Get(CancellationToken cancellationToken)
        => await _companyBranchService.GetByCompanyBinarySignAsync(cancellationToken);
}