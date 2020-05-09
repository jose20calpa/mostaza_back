using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Articulos
    {
        public Articulos()
        {
            ArticulosImagenes = new HashSet<ArticulosImagenes>();
            Donaciones = new HashSet<Donaciones>();
            Reservas = new HashSet<Reservas>();
        }

        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int IdUsuario { get; set; }
        public int IdDireccion { get; set; }
        public int IdEstadoArituculo { get; set; }
        public int IdUnidadMedida { get; set; }

        public virtual Direcciones IdDireccionNavigation { get; set; }
        public virtual EstadosArticulos IdEstadoArituculoNavigation { get; set; }
        public virtual UnidadesMedidas IdUnidadMedidaNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
        public virtual ICollection<ArticulosImagenes> ArticulosImagenes { get; set; }
        public virtual ICollection<Donaciones> Donaciones { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }
    }
}
