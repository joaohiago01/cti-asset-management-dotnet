using System.Threading;
using System.Threading.Tasks;
using CTI.Asset.Management.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace CTI.Asset.Management.Infrastructure
{
    public interface IApplicationContext
    {
        DbSet<SoftwareLicenseModel> SoftwareLicenses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}