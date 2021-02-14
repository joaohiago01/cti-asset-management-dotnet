using CTI.Asset.Management.Application.Exceptions;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.CreateSoftwareLicenseUseCase;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;
using CTI.Asset.Management.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace CTI.Asset.Management.WebAPI.Controllers.SoftwareLicense
{
    [ApiController]
    [Area("/SoftwareLicense")]
    public class CreateSoftwareLicenseController : ControllerBase
    {
        private readonly ICreateSoftwareLicenseUseCase _createSoftwareLicenseUseCase;

        public CreateSoftwareLicenseController(ICreateSoftwareLicenseUseCase createSoftwareLicenseUseCase)
        {
            _createSoftwareLicenseUseCase = createSoftwareLicenseUseCase;
        }
        
        [HttpPost]
        public IActionResult Handle([FromBody] string activationKey)
        {
            var softwareLicenseDto = new CreateSoftwareLicenseDto
            {
                ActivationKey = new SoftwareLicenseActivationKey(activationKey)
            };
            
            var softwareLicenseRegistered = _createSoftwareLicenseUseCase.Execute(softwareLicenseDto);

            if (softwareLicenseRegistered == null)
            {
                Problem(new TaskNotCreated().Message, null, 500);
            }

            return Ok();
        }
    }
}