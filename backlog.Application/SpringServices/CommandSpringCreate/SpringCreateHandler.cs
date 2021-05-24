using backlog.Domain.Entities;
using backlog.Domain.Factory;
using backlog.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace backlog.Application.SpringServices.CommandSpringCreate
{
    public class SpringCreateHandler : IRequestHandler<SpringCreate, SpringCreateDTO>
    {
        private readonly IFactory factory;

        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public SpringCreateHandler(IFactory factory, IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.factory = factory;
            this.autoMapping = autoMapping;
        }

        public async Task<SpringCreateDTO> Handle(SpringCreate request, CancellationToken cancellationToken)
        {
            //crear
            var sprint = (Sprint) this.factory.CreateSprint(request.Desde, request.Hasta);

            //guardar
            sprint = await this.repository.Save<Sprint>(sprint, cancellationToken);

            //mapear y retonar
            return this.autoMapping.Map<Sprint, SpringCreateDTO>(sprint);
        }
    }
}
