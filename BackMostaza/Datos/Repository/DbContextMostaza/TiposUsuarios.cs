using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTiposUsuarios { get; set; }
        public string TipoUsuario { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
