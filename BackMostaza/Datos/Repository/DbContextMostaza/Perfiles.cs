using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Perfiles
    {
        public Perfiles()
        {
            Direcciones = new HashSet<Direcciones>();
        }

        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public byte[] Fotografia { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<Direcciones> Direcciones { get; set; }
    }
}
