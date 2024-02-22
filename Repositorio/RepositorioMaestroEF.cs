using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioMaestroEF : IRepositorioMaestro
    {
        private Modelo.Contexto contexto;
        public RepositorioMaestroEF()
        {
            contexto = new Modelo.Contexto();
        }

        public List<Ciudad> ObtenerCiudades(int idDepartamento)
        {
            var ciudades = contexto.Ciudades.Where(d => d.Id == idDepartamento)
                .Select(c => new Ciudad() { Id = c.Id, Nombre = c.Nombre } )
                .OrderBy(c => c.Nombre)
                .ToList();

            return ciudades;
        }

        public List<Departamento> ObtenerDepartamentos()
        {
            return contexto.Departamentos
                .Select(c => new Departamento() { Id = c.Id, Nombre = c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            return contexto.TiposDocumentos
                .Select(c => new TipoDocumento() { Id = c.Id, Nombre = c.Nombre })
                .OrderBy(c => c.Nombre)
                .ToList();
        }
    }
}
