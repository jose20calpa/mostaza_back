using System.Threading.Tasks;
using Datos.Repository.DbContextMostaza;

namespace DatosLayer.Repository.Repositorios
{
    public interface IPerfilRepositorio
    {
        Task<int> CrearPerfilAsync(Perfiles perfil);
        Task<Perfiles> EncontrarPerfilPorIdUsuario(int idUsuario);
        Task<int> ModificarUsuarioAsync(Perfiles perfil);
    }
}