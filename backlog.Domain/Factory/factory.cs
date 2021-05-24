using backlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Factory
{
    public class factory : IFactory
    {
        public Entity CreateEpic(string nombre, string descripcion, string sprintId)
        {
            return new Epic(nombre,  descripcion, sprintId);
        }

        public Entity CreateFeature(string nombre, string historial, string epicId)
        {
            return new Feature(nombre, historial, epicId);
        }

        public Entity CreateJobs(string nombre, string featureId, string asignacion, int colaboradores)
        {
            return new Job(nombre, featureId, asignacion, colaboradores);
        }

        public Entity CreateSprint(string desde, string hasta)
        {
            return new Sprint(desde, hasta);
        }
    }
}
