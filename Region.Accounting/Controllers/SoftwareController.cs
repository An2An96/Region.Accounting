using System;
using Microsoft.AspNetCore.Mvc;
using Region.Accounting.Application.Software.Commands.CreateSoftware;
using Region.Accounting.Controllers.Dto;
using Region.Accounting.Domain.Software;
using Region.Mediator.Command;

namespace Region.Accounting.Controllers
{
    [ApiController]
    [Route("software")]
    public class SoftwareController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public SoftwareController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public void CreateSoftware(CreateSoftwareDto dto)
        {
            switch (dto.Kind)
            {
                case SoftwareKindDto.Free:
                {
                    _commandBus.Handle(new CreateFreeSoftwareCommand(dto.Vendor, dto.Name, MapSoftwareType(dto.Type)));
                    break;
                }
                case SoftwareKindDto.Licensed:
                {
                    _commandBus.Handle(new CreateLicensedSoftwareCommand(dto.Vendor, dto.Name, MapSoftwareType(dto.Type)));
                    break;
                }
                case SoftwareKindDto.Own:
                {
                    _commandBus.Handle(new CreateOwnSoftwareCommand(dto.Vendor, dto.Name, MapSoftwareType(dto.Type)));
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private SoftwareType MapSoftwareType(SoftwareTypeDto dto)
        {
            return dto switch
            {
                SoftwareTypeDto.User => SoftwareType.User,
                SoftwareTypeDto.Server => SoftwareType.Server,
                SoftwareTypeDto.Common => SoftwareType.Common,
                SoftwareTypeDto.Special => SoftwareType.Special,
                _ => throw new ArgumentOutOfRangeException(nameof(dto), dto, null)
            };
        }
    }
}