using Entidades;

namespace Repositorio
{
    public interface IRepositorioSeguridad
    {
        Usuario ObtenerUsuario(string nombreUsuario);
    }
}