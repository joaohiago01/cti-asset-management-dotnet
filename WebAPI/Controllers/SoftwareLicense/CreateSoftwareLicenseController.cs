using CTI.Asset.Management.Application.Exceptions;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.Command.CreateSoftwareLicenseUseCase;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;
using CTI.Asset.Management.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CTI.Asset.Management.WebAPI.Controllers.SoftwareLicense
{
    public class CreateSoftwareLicenseRequest : IRequest
    {
        public string ActivationKey { get; set; }    
    }
    
    [ApiController]
    [Area("/CreateSoftwareLicense")]
    public class CreateSoftwareLicenseController : Controller
    {
        private readonly ICreateSoftwareLicenseUseCase _createSoftwareLicenseUseCase;

        public CreateSoftwareLicenseController(ICreateSoftwareLicenseUseCase createSoftwareLicenseUseCase)
        {
            _createSoftwareLicenseUseCase = createSoftwareLicenseUseCase;
        }
        
        [HttpPost]
        public IActionResult Execute(CreateSoftwareLicenseRequest request)
        {
            var softwareLicenseDto = new CreateSoftwareLicenseDto
            {
                ActivationKey = new SoftwareLicenseActivationKey(request.ActivationKey)
            };
            
            var softwareLicenseRegistered = _createSoftwareLicenseUseCase.Execute(softwareLicenseDto);

            if (softwareLicenseRegistered == null)
            {
                Problem(new SoftwareLicenseNotCreated().Message, null, 500);
            }

            return Ok();
        }
    }
}