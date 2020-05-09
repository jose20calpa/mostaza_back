using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository
{
    public interface IRepositorioGenerico<T> where T : class
    {
        Task<IEnumerable<T>> ListarEntidadesAsync();
        Task<IEnumerable<T>> ListarEntidadesCondicionalesAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        Task<T> EncontrarUnico(Expression<Func<T, bool>> Condition);
        Task<T> CrearEntidadAsync(T entidad);
    }
}
