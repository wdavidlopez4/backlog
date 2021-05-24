using backlog.Application.EpicService.CommandEpicAssignToSpring;
using backlog.Application.SpringServices.CommandSpringCreate;
using backlog.Application.SpringServices.QuerySpringByMonth;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backlog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BacklogController : ControllerBase
    {
        private readonly IMediator mediator;

        public BacklogController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("Sprin")]
        public async Task<IActionResult> RegistrarSprin(SpringCreate springCreate)
        {
            if (! ModelState.IsValid)
                return BadRequest("el modelo enviado es incorrecto");

            var dto = await mediator.Send(springCreate);
            if (dto == null)
                return BadRequest("no hay respuesta en el servicio.");

            return Ok(dto);
        }

        [HttpGet]
        [Route("MesSprints")]
        public async Task<IActionResult> ConsultarSprintPorMes([Bind("nombreMes")] string nombreMes)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo enviado es incorrecto");

            var dto = await mediator.Send(new SpringByMonth { NombreMes = nombreMes});
            if (dto == null)
                return BadRequest("no hay respuesta en el servicio.");

            return Ok(dto);
        }

        [HttpPost]
        [Route("AssignToSpring")]
        public async Task<IActionResult> AsignarEpicoASpring(EpicAssignToSpring epicAssignToSpring)
        {
            if (!ModelState.IsValid)
                return BadRequest("el modelo enviado es incorrecto");

            var dto = await mediator.Send(epicAssignToSpring);
            if (dto == null)
                return BadRequest("no hay respuesta en el servicio.");

            return Ok(dto);
        }
    }
}
