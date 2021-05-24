using AutoMapper;
using backlog.Application.EpicService.CommandEpicAssignToSpring;
using backlog.Application.SpringServices.CommandSpringCreate;
using backlog.Application.SpringServices.QuerySpringByMonth;
using backlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Infrastructure.Mapping
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            this.CreateMap<Sprint, SpringCreateDTO>();
            this.CreateMap<Sprint, SpringByMonthDTO>(); 
            this.CreateMap<Epic, EpicAssignToSpringDTO>();
        }
    }
}
