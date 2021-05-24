using backlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Factory
{
    public interface IFactory
    {
        public Entity CreateEpic(string nombre, string descripcion, string sprintId);

        public Entity CreateFeature(string nombre, string historial, string epicId);

        public Entity CreateJobs(string nombre, string featureId, string asignacion, int colaboradores);

        public Entity CreateSprint(string desde, string hasta);
    }
}
