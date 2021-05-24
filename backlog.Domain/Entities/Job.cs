using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Entities
{
    public class Job : Entity
    {
        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }

        public string Asignacion { get; private set; }

        public int Colaboradores { get; private set; }

        public Feature Feature { get; private set; }

        public string FeatureId { get; private set; }

        internal Job(string nombre, string featureId, string asignacion, int colaboradores)
        {
            this.Nombre = nombre;
            this.FeatureId = featureId;
            this.Asignacion = asignacion;
            this.Colaboradores = colaboradores;
        }

        private Job()
        {

        }
    }
}
