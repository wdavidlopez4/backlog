using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Entities
{
    public class Epic : Entity
    {
        public string Nombre { get; private set; }

        public string Descripcion { get; private set; }

        public List<Feature> Features { get; private set; }

        public Sprint Sprint { get; private set; }

        public string SprintId { get; private set; }

        internal Epic(string nombre, string descripcion, string sprintId)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.SprintId = sprintId;
        }

        private Epic()
        {
            //for EF
        }
    }
}
