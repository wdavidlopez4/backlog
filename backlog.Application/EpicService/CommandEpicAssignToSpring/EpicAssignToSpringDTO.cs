using backlog.Domain.Entities;
using backlog.Domain.Factory;
using backlog.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace backlog.Application.EpicService.CommandEpicAssignToSpring
{
    public class EpicAssignToSpringDTO 
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string SprintId { get; set; }
    }
}
