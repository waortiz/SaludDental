using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class RepositorioSeguridad : IRepositorioSeguridad
    {
        private Modelo.Contexto contexto;
        public RepositorioSeguridad()
        {
            contexto = new Modelo.Contexto();
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            var usuarioActual = contexto.Usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);
            if (usuarioActual != null)
            {
                return new Usuario()
                {
                    NombreUsuario = usuarioActual.NombreUsuario,
                    Clave = usuarioActual.Clave
                };
            }

            return null;
        }

    }
}
