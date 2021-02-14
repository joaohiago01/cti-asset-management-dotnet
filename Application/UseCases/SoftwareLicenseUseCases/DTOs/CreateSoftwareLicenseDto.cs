using CTI.Asset.Management.Domain.ValueObjects;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs
{
    public class CreateSoftwareLicenseDto
    {
        public SoftwareLicenseActivationKey ActivationKey { get; set; }
    }
}