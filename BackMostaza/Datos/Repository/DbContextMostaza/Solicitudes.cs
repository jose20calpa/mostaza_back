using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Solicitudes
    {
        public int IdSolicitud { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstadoSolicitud { get; set; }

        public virtual EstadosSolicitudes IdEstadoSolicitudNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
