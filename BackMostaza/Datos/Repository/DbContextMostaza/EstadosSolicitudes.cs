using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class EstadosSolicitudes
    {
        public EstadosSolicitudes()
        {
            Solicitudes = new HashSet<Solicitudes>();
        }

        public int IdEstadoSolicitud { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Solicitudes> Solicitudes { get; set; }
    }
}
