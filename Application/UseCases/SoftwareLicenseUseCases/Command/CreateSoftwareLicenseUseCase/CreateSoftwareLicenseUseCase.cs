using System.Threading.Tasks;
using CTI.Asset.Management.Application.Contracts.Repositories;
using CTI.Asset.Management.Application.Exceptions;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;
using CTI.Asset.Management.Domain.Entities;
using CTI.Asset.Management.Domain.Event;
using CTI.Asset.Management.Domain.ValueObjects;

namespace CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.Command.CreateSoftwareLicenseUseCase
{
    public class CreateSoftwareLicenseUseCase : ICreateSoftwareLicenseUseCase
    {
        private readonly ISoftwareLicenseRepository _softwareLicenseRepository;

        public CreateSoftwareLicenseUseCase(ISoftwareLicenseRepository softwareLicenseRepository)
        {
            _softwareLicenseRepository = softwareLicenseRepository;
        }

        public async Task<ReadSoftwareLicenseDto> Execute(CreateSoftwareLicenseDto softwareLicenseDto)
        {
            var id = new SoftwareLicenseId();
            var activationKey = softwareLicenseDto.ActivationKey;
            var softwareLicense = new SoftwareLicense(id, activationKey);
            
            var registeredSoftwareLicense = await _softwareLicenseRepository.CreateSoftwareLicense(softwareLicense);

            if (registeredSoftwareLicense == null)
            {
                throw new InternalError();
            }
            
            softwareLicense.DomainEvents.Add(new SoftwareLicenseCreatedEvent(softwareLicense));

            var readSoftwareLicenseDto = new ReadSoftwareLicenseDto
            {
                Id = registeredSoftwareLicense.Id,
                ActivationKey = registeredSoftwareLicense.ActivationKey
            };

            return readSoftwareLicenseDto;
        }
    }
}