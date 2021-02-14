using CTI.Asset.Management.Domain.ValueObjects;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs
{
    public class EditSoftwareLicenseDto
    {
        public SoftwareLicenseId Id { get; set; }
        public SoftwareLicenseActivationKey ActivationKey { get; set; }
    }
}