using Entidades;

namespace Repositorio
{
    public interface IRepositorioMaestro
    {
        List<Ciudad> ObtenerCiudades(int idDepartamento);
        List<Departamento> ObtenerDepartamentos();
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}