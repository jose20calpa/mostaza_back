using System.Threading.Tasks;
using Datos.Repository.DbContextMostaza;

namespace DatosLayer.Repository.Repositorios
{
    public interface IUsuariorepositorio
    {
        Task<int> CrearUsuarioAsync(Usuarios usuario);
        Task<Usuarios> EncontrarUsuarioPorEmail(Usuarios usuario);
        Task<int> ModificarUsuarioAsync(Usuarios usuario);
    }
}