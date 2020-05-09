using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Donaciones
    {
        public int IdDonacion { get; set; }
        public int IdArticulo { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Articulos IdArticuloNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
