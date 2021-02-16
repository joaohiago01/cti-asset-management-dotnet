using System.Collections.Generic;
using System.Linq;
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
            _context = context;
        }
        public async Task<SoftwareLicenseModel> CreateSoftwareLicense(SoftwareLicense softwareLicense)
        {
            var softwareLicenseModel = SoftwareLicenseModel.ToModel(softwareLicense);
            await _context.Database.BeginTransactionAsync();
            await _context.Set<SoftwareLicenseModel>().AddAsync(softwareLicenseModel);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return softwareLicenseModel;
        }

        public async Task<SoftwareLicenseModel> EditSoftwareLicense(SoftwareLicense softwareLicense)
        {
            var softwareLicenseModel = SoftwareLicenseModel.ToModel(softwareLicense);
            await _context.Database.BeginTransactionAsync();
            _context.Set<SoftwareLicenseModel>().Update(softwareLicenseModel);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return softwareLicenseModel;
        }

        public async void DeleteSoftwareLicense(SoftwareLicense softwareLicense)
        {
            var softwareLicenseModel = SoftwareLicenseModel.ToModel(softwareLicense);
            await _context.Database.BeginTransactionAsync();
            _context.Set<SoftwareLicenseModel>().Remove(softwareLicenseModel);
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }

        public async Task<SoftwareLicenseModel> GetSoftwareLicense(string softwareLicenseId)
        {
            await _context.Database.BeginTransactionAsync();
            
            var softwareLicenseModel =
                (from model in _context.Set<SoftwareLicenseModel>()
                where model.Id == softwareLicenseId
                select model).FirstOrDefault();
                
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return softwareLicenseModel;
        }
        
        public async Task<SoftwareLicenseModel> GetByActivationKey(string activationKey)
        {
            await _context.Database.BeginTransactionAsync();
            
            var softwareLicenseModel =
                (from model in _context.Set<SoftwareLicenseModel>()
                    where model.ActivationKey == activationKey
                    select model).FirstOrDefault();
                
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return softwareLicenseModel;
        }

        public async Task<List<SoftwareLicenseModel>> GetAllSoftwareLicenses()
        {
            await _context.Database.BeginTransactionAsync();
            
            var softwareLicensesModels = 
                from model in _context.Set<SoftwareLicenseModel>() 
                select model;
                
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
            return softwareLicensesModels.ToList();
        }
    }
}