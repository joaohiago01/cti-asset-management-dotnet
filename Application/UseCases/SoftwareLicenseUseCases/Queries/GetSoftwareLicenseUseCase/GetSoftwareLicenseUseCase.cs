using System.Threading.Tasks;
using CTI.Asset.Management.Application.Contracts.Repositories;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.Queries.GetSoftwareLicenseUseCase
{
    public class GetSoftwareLicenseUseCase : IGetSoftwareLicenseUseCase
    {
        private readonly ISoftwareLicenseRepository _softwareLicenseRepository;

        public GetSoftwareLicenseUseCase(ISoftwareLicenseRepository softwareLicenseRepository)
        {
            _softwareLicenseRepository = softwareLicenseRepository;
        }
        
        public async Task<ReadSoftwareLicenseDto> Execute(ReadSoftwareLicenseDto softwareLicenseDto)
        {
            var softwareLicense = await _softwareLicenseRepository.GetSoftwareLicense(softwareLicenseDto.Id);
            
            var readSoftwareLicenseDto = new ReadSoftwareLicenseDto
            {
                Id = softwareLicense.Id,
                ActivationKey = softwareLicense.ActivationKey
            };

            return readSoftwareLicenseDto;
        }
    }
}