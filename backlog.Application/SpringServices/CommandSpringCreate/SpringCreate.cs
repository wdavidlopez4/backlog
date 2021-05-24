using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Application.SpringServices.CommandSpringCreate
{
    public class SpringCreate : IRequest<SpringCreateDTO>
    {
        public string Desde { get; set; }

        public string Hasta { get; set; }
    }
}
