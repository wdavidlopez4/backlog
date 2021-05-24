using backlog.Domain.Entities;
using backlog.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace backlog.Application.SpringServices.QuerySpringByMonth
{
    public class SpringByMonthHandler : IRequestHandler<SpringByMonth, List<SpringByMonthDTO>>
    {
        private readonly IRepository repository;

        private readonly IAutoMapping autoMapping;

        public SpringByMonthHandler(IRepository repository, IAutoMapping autoMapping)
        {
            this.repository = repository;
            this.autoMapping = autoMapping;
        }

        public async Task<List<SpringByMonthDTO>> Handle(SpringByMonth request, CancellationToken cancellationToken)
        {
            //recuperar todos los sprint que comiensen en abril
            var sprints = await this.repository.Gets<Sprint>((x) => x.Desde == request.NombreMes, cancellationToken);

            //retornar y mapear
            return this.autoMapping.Map<List<Sprint>, List<SpringByMonthDTO>>(sprints);
        }
    }
}
