using System.Linq.Expressions;
using Core.TavridaTask.Entities;
using Core.TavridaTask.Interfaces.Repositories;
using Core.TavridaTask.Interfaces.Services;
using Moq;

namespace Test.TavridaTask.Services.CompanyBranchService;

public class GetCompanyBranchesByCompanyBinarySignTest
{
    private readonly Mock<IGenericRepository<CompanyBranch>> _companyBranchRepository;

    public GetCompanyBranchesByCompanyBinarySignTest()
    {
        this._companyBranchRepository = new Mock<IGenericRepository<CompanyBranch>>();
    }
    
    [Fact]
    public async Task ShouldReturnEmptyIfNotResult()
    {
        _companyBranchRepository.Setup(rep =>
                rep.AllWhereAsync(CancellationToken.None, It.IsAny<Expression<Func<CompanyBranch, dynamic>>?>(),
                    default))
            .ReturnsAsync(new List<CompanyBranch>(0));

        ICompanyBranchService service =
            new Core.TavridaTask.Services.CompanyBranchService(_companyBranchRepository.Object);

        var res = await service.GetByCompanyBinarySignAsync(CancellationToken.None);

        Assert.NotNull(res);
        Assert.Empty(res.CompanyBranches);
    }

    [Fact]
    public async Task ShouldReturnCompanyAssociatedBranchesIdsIfBinarySignFalse()
    {
        _companyBranchRepository.Setup(rep =>
                rep.AllWhereAsync(CancellationToken.None, It.IsAny<Expression<Func<CompanyBranch, dynamic>>?>(),
                    default))
            .ReturnsAsync(new List<CompanyBranch>()
            {
                new()
                {
                    Id = 1,
                    Name = "CompanyBranch1",
                    Company = new()
                    {
                        Id = 1,
                        Name = "Company",
                        BinarySign = false
                    },
                    CompanyId = 1,
                },
                new()
                {
                    Id = 2,
                    Name = "CompanyBranch2",
                    Company = new()
                    {
                        Id = 1,
                        Name = "Company1",
                        BinarySign = false
                    },
                    CompanyId = 1,
                },
            });

        ICompanyBranchService service =
            new Core.TavridaTask.Services.CompanyBranchService(_companyBranchRepository.Object);

        var res = await service.GetByCompanyBinarySignAsync(CancellationToken.None);

        Assert.NotEmpty(res.CompanyBranches);
        Assert.Equal(2, res.CompanyBranches.Count);
        Assert.All(res.CompanyBranches, branch => Assert.False(branch.CompanyBinarySign));
    }

    [Fact]
    public async Task ShouldReturnAllAssociatedBranchesIdsIfBinarySignTrue()
    {
        _companyBranchRepository.Setup(rep =>
                rep.AllWhereAsync(CancellationToken.None, It.IsAny<Expression<Func<CompanyBranch, dynamic>>?>(),
                    default))
            .ReturnsAsync(new List<CompanyBranch>()
            {
                new()
                {
                    Id = 1,
                    Name = "CompanyBranch1",
                    Company = new()
                    {
                        Id = 3,
                        Name = "Company",
                        BinarySign = true
                    },
                    CompanyId = 3,
                },
                new()
                {
                    Id = 2,
                    Name = "CompanyBranch2",
                    Company = new()
                    {
                        Id = 4,
                        Name = "Company1",
                        BinarySign = true
                    },
                    CompanyId = 4,
                },
            });

        var associatedBranchesIds = new int[2]
        {
            1, 2
        };
        
        ICompanyBranchService service =
            new Core.TavridaTask.Services.CompanyBranchService(_companyBranchRepository.Object);

        var res = await service.GetByCompanyBinarySignAsync(CancellationToken.None);

        Assert.NotEmpty(res.CompanyBranches);
        Assert.Equal(2, res.CompanyBranches.Count);
        Assert.All(res.CompanyBranches, branch => Assert.True(branch.CompanyBinarySign));
        Assert.All(res.CompanyBranches, branch =>
        {
            Assert.Equal(associatedBranchesIds, branch.AssociatedBranchesIds); 
        });
    }
}