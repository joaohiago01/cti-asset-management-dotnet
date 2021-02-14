using System.Threading.Tasks;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.CreateSoftwareLicenseUseCase
{
    public interface ICreateSoftwareLicenseUseCase
    {
        public Task<ReadSoftwareLicenseDto> Execute(CreateSoftwareLicenseDto softwareLicenseDto);
    }
}