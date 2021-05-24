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
    public class EpicAssignToSpringHandler : IRequestHandler<EpicAssignToSpring, EpicAssignToSpringDTO>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        private readonly IFactory factory;

        public EpicAssignToSpringHandler(IRepository repository, IAutoMapping autoMapping, IFactory factory)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
            this.factory = factory;
        }

        public async Task<EpicAssignToSpringDTO> Handle(EpicAssignToSpring request, CancellationToken cancellationToken)
        {
            //crear
            var epic = (Epic)this.factory.CreateEpic(
                nombre: request.Nombre,
                descripcion: request.Descripcion,
                sprintId: request.SprintId);

            //guardar
            epic = await this.repository.Save<Epic>(epic, cancellationToken);

            //mapear y repornar
            return this.autoMapping.Map<Epic, EpicAssignToSpringDTO>(epic);

        }
    }
}
