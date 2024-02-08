using Entidades;

namespace Negocio
{
    public interface INegocioMaestro
    {
        List<Departamento> ObtenerDepartamentos();
        List<Ciudad> ObtenerCiudades(int idDepartamento);
        List<TipoDocumento> ObtenerTiposDocumento();
    }
}