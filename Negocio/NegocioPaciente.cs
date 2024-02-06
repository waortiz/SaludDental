using Entidades;
using Repositorio;

namespace Negocio
{
    public class NegocioPaciente : INegocioPaciente
    {
        IRepositorioPaciente repositorioPaciente;
        public NegocioPaciente(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public void ActualizarPaciente(Paciente paciente)
        => this.repositorioPaciente.ActualizarPaciente(paciente);

        public void IngresarPaciente(Paciente paciente)
        => this.repositorioPaciente.IngresarPaciente(paciente);

        public Paciente ObtenerPaciente(string numeroDocumento)
        => this.repositorioPaciente.ObtenerPaciente(numeroDocumento);
    }
}