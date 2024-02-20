using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMaestro : INegocioMaestro
    {
        IRepositorioMaestro repositorioMaestro = new RepositorioMaestroADO();
        public NegocioMaestro(IRepositorioMaestro repositorioMaestro)
        {
            this.repositorioMaestro = repositorioMaestro;
        }

        public List<Ciudad> ObtenerCiudades(int idDepartamento)
        => repositorioMaestro.ObtenerCiudades(idDepartamento);

        public List<Departamento> ObtenerDepartamentos()
        => repositorioMaestro.ObtenerDepartamentos();

        public List<TipoDocumento> ObtenerTiposDocumento()
        => repositorioMaestro.ObtenerTiposDocumento();
    }
}
