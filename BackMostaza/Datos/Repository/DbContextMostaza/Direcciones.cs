using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Direcciones
    {
        public Direcciones()
        {
            Articulos = new HashSet<Articulos>();
        }

        public int IdDireccion { get; set; }
        public string Direccion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Referencia { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Ciudad { get; set; }
        public int IdPerfil { get; set; }
        public string Tag { get; set; }
        public bool DireccionPrincipal { get; set; }

        public virtual Perfiles IdPerfilNavigation { get; set; }
        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
