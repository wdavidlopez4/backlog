using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Application.EpicService.CommandEpicAssignToSpring
{
    public class EpicAssignToSpring : IRequest<EpicAssignToSpringDTO>
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string SprintId { get; set; }
    }
}
