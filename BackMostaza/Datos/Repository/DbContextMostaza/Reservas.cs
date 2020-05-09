using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Reservas
    {
        public int IdReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public DateTime FechaMaxima { get; set; }
        public int IdEstadoReserva { get; set; }
        public int IdUsuario { get; set; }
        public int IdArticulo { get; set; }

        public virtual Articulos IdArticuloNavigation { get; set; }
        public virtual EstadosReservas IdEstadoReservaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
