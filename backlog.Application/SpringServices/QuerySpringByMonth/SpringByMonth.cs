using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Application.SpringServices.QuerySpringByMonth
{
    public class SpringByMonth : IRequest<List<SpringByMonthDTO>>
    {
        public string NombreMes { get; set; }
    }
}
