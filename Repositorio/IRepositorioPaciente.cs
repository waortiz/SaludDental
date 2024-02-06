using Entidades;

namespace Repositorio
{
    public interface IRepositorioPaciente
    {
        void IngresarPaciente(Paciente paciente);
        void ActualizarPaciente(Paciente paciente);
        Paciente ObtenerPaciente(string numeroDocumento);
    }
}