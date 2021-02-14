using System.Collections.Generic;
using System.Threading.Tasks;
using CTI.Asset.Management.Application.Contracts.Repositories;
using CTI.Asset.Management.Domain.Entities;
using CTI.Asset.Management.Infrastructure.Repositories.Models;

namespace CTI.Asset.Management.Infrastructure.Repositories
{
    public class SoftwareLicenseRepository : ISoftwareLicenseRepository
    {
        private readonly ApplicationContext _context;

        public SoftwareLicenseRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<SoftwareLicenseModel> CreateSoftwareLicense(SoftwareLicense softwareLicense)
        {
            var softwareLicenseModel = SoftwareLicenseModel.ToModel(softwareLicense);
            await _context.Database.BeginTransactionAsync();
            await _context.Set<SoftwareLicenseModel>().AddAsync(softwareLicenseModel);
            await _context.Database.CommitTransactionAsync();
            return softwareLicenseModel;
        }

        public Task<SoftwareLicenseModel> EditSoftwareLicense(SoftwareLicense softwareLicense)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteSoftwareLicense(SoftwareLicense softwareLicense)
        {
            throw new System.NotImplementedException();
        }

        public Task<SoftwareLicenseModel> GetSoftwareLicense(SoftwareLicense softwareLicense)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SoftwareLicenseModel>> GetAllSoftwareLicenses()
        {
            throw new System.NotImplementedException();
        }
    }
}