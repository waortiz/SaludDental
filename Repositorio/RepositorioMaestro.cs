using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioMaestro : IRepositorioMaestro
    {
        public List<Ciudad> ObtenerCiudades(int idDepartamento)
        {
            var departamentos = ObtenerDepartamentos();
            var ciudades = departamentos.FirstOrDefault(d => d.Id == idDepartamento)
                .Select(d => d.Ciudades)
                .OrderBy(c => c.Nombre)
                .ToList();

            return ciudades;
        }

        public List<Departamento> ObtenerDepartamentos()
        {
            var departamentos = new List<Departamento>();

            departamentos.Add(new Departamento() { Id = 1, Nombre = "Antioquia", Ciudades = new List<Ciudad>() });
            departamentos[0].Ciudades.Add(new Ciudad() { Id = 1, Nombre = "Medellín" });
            departamentos[0].Ciudades.Add(new Ciudad() { Id = 2, Nombre = "Bello" });
            departamentos[0].Ciudades.Add(new Ciudad() { Id = 3, Nombre = "Sabaneta" });

            departamentos.Add(new Departamento() { Id = 2, Nombre = "Córdoba", Ciudades = new List<Ciudad>() });
            departamentos[1].Ciudades.Add(new Ciudad() { Id = 4, Nombre = "Sahagún" });
            departamentos[1].Ciudades.Add(new Ciudad() { Id = 5, Nombre = "Montería" });
            departamentos[1].Ciudades.Add(new Ciudad() { Id = 6, Nombre = "Tierralta" });

            departamentos.Add(new Departamento() { Id = 3, Nombre = "Atlántico", Ciudades = new List<Ciudad>() });
            departamentos[2].Ciudades.Add(new Ciudad() { Id = 7, Nombre = "Barranquilla" });
            departamentos[2].Ciudades.Add(new Ciudad() { Id = 8, Nombre = "Sabanalarga" });
            departamentos[2].Ciudades.Add(new Ciudad() { Id = 9, Nombre = "Malambo" });

            return departamentos;
        }

        public List<TipoDocumento> ObtenerTiposDocumento()
        {
            var tiposDocumento = new List<TipoDocumento>();

            tiposDocumento.Add(new TipoDocumento() { Id = 1, Nombre = "Cédula de Ciudadanía" });
            tiposDocumento.Add(new TipoDocumento() { Id = 2, Nombre = "Cédula de Extranjería" });
            tiposDocumento.Add(new TipoDocumento() { Id = 3, Nombre = "Tarjeta de Identidad" });

            return tiposDocumento;
        }
    }
}
