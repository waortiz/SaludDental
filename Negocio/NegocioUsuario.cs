using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario : INegocioUsuario
    {
        IRepositorioSeguridad repositorioSeguridad;
        public NegocioUsuario(IRepositorioSeguridad repositorioSeguridad)
        {
            this.repositorioSeguridad = repositorioSeguridad;
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            var usuario = repositorioSeguridad.ObtenerUsuario(nombreUsuario);
            if(usuario!=null && usuario.Clave == clave && usuario.NombreUsuario == nombreUsuario)
            {
                return true;
            }

            return false;
        }
    }
}
