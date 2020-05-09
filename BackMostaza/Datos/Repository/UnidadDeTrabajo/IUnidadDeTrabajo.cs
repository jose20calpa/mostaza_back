
using Datos.Repository.DbContextMostaza;

namespace Datos.Repository.UnidadDeTrabajo
{
    public interface IUnidadDeTrabajo<T> where T : class
    {

        void Commit();
        void Dispose();
        void RejectChanges();
    }
}