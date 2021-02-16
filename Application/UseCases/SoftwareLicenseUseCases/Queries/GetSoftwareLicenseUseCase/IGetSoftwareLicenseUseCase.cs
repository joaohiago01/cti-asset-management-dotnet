using System.Threading.Tasks;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.Queries.GetSoftwareLicenseUseCase
{
    public interface IGetSoftwareLicenseUseCase
    {
        public Task<ReadSoftwareLicenseDto> Execute(ReadSoftwareLicenseDto softwareLicenseDto);
    }
}