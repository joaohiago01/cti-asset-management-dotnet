using System.Collections.Generic;
using System.Threading.Tasks;
using CTI.Asset.Management.Domain.Entities;
using CTI.Asset.Management.Infrastructure.Repositories.Models;

namespace CTI.Asset.Management.Application.Contracts.Repositories
{
    public interface ISoftwareLicenseRepository
    {
        public Task<SoftwareLicenseModel> CreateSoftwareLicense(SoftwareLicense softwareLicense);

        public Task<SoftwareLicenseModel> EditSoftwareLicense(SoftwareLicense softwareLicense);

        public void DeleteSoftwareLicense(SoftwareLicense softwareLicense);

        public Task<SoftwareLicenseModel> GetSoftwareLicense(SoftwareLicense softwareLicense);

        public Task<List<SoftwareLicenseModel>> GetAllSoftwareLicenses();
    }
}