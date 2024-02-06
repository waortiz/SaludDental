using Entidades;

namespace Negocio
{
    public interface INegocioPaciente
    {
        void IngresarPaciente(Paciente paciente);
        void ActualizarPaciente(Paciente paciente);
        Paciente ObtenerPaciente(string numeroDocumento);
    }
}