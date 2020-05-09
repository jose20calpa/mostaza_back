using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class EstadosReservas
    {
        public EstadosReservas()
        {
            Reservas = new HashSet<Reservas>();
        }

        public int IdEstadoReserva { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
