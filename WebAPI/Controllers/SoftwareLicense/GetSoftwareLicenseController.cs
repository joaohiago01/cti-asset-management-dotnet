using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.DTOs;
using CTI.Asset.Management.Application.UseCases.SoftwareLicenseUseCases.Queries.GetSoftwareLicenseUseCase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CTI.Asset.Management.WebAPI.Controllers.SoftwareLicense
{
    public class ReadSoftwareLicenseRequest : IRequest
    {
        public string Id { get; set; }    
    }
    
    [ApiController]
    [Area("/GetSoftwareLicense")]
    public class GetSoftwareLicenseController : Controller
    {
        private readonly IGetSoftwareLicenseUseCase _getSoftwareLicenseUseCase;

        public GetSoftwareLicenseController(IGetSoftwareLicenseUseCase getSoftwareLicenseUseCase)
        {
            _getSoftwareLicenseUseCase = getSoftwareLicenseUseCase;
        }
        
        [HttpGet]
        public IActionResult Execute(ReadSoftwareLicenseRequest request)
        {
            var softwareLicenseDto = new ReadSoftwareLicenseDto()
            {
                Id = request.Id
            };
            
            var softwareLicense = _getSoftwareLicenseUseCase.Execute(softwareLicenseDto);

            return Json(softwareLicense);
        }
    }
}