using Datos.Repository.DbContextMostaza;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Datos.Repository.UnidadDeTrabajo
{
    public class UnidadDeTrabajo<T> : IUnidadDeTrabajo<T> where T : class
    {
        private readonly DbMostazaContext dataContext;

        public IRepositorioGenerico<T> ProductRepository => new RepositorioGenerico<T>(dataContext);

        public UnidadDeTrabajo(DbMostazaContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }

        public void RejectChanges()
        {
            foreach (var item in dataContext.ChangeTracker.Entries().Where(i => i.State != EntityState.Unchanged))
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        item.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                    case EntityState.Modified:
                        item.Reload();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
