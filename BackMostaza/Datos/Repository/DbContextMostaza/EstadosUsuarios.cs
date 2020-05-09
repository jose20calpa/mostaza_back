using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class EstadosUsuarios
    {
        public EstadosUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdEstadoUsuario { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
