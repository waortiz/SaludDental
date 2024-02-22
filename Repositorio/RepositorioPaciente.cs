using Entidades;

namespace Repositorio
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private Modelo.Contexto contexto;
        public RepositorioPaciente()
        {
            contexto = new Modelo.Contexto();
        }

        public void IngresarPaciente(Paciente paciente)
        {
            Modelo.Paciente pacienteIngresar = new Modelo.Paciente()
            {
                PrimerNombre = paciente.PrimerNombre,
                SegundoNombre = paciente.SegundoNombre,
                PrimerApellido = paciente.PrimerApellido,
                SegundoApellido = paciente.SegundoApellido,
                NumeroDocumento = paciente.NumeroDocumento,
                IdTipoDocumento = paciente.TipoDocumento.Id,
                Direccion = paciente.Direccion,
                IdCiudad = paciente.Ciudad.Id,
                FechaNacimiento = paciente.FechaNacimiento,
                Salario = paciente.Salario,
                Telefono = paciente.Telefono,
                Celular = paciente.Celular,
                Titular = paciente.Titular,
                IdSexo = paciente.Sexo.Id
            };

            contexto.Pacientes.Add(pacienteIngresar);
            contexto.SaveChanges();
        }

        public void ActualizarPaciente(Paciente paciente)
        {
            var pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            pacienteActual.PrimerNombre = paciente.PrimerNombre;
            pacienteActual.SegundoNombre = paciente.SegundoNombre;
            pacienteActual.PrimerApellido = paciente.PrimerApellido;
            pacienteActual.SegundoApellido = paciente.SegundoApellido;
            pacienteActual.NumeroDocumento = paciente.NumeroDocumento;
            pacienteActual.IdTipoDocumento = paciente.TipoDocumento.Id;
            pacienteActual.Direccion = paciente.Direccion;
            pacienteActual.IdCiudad = paciente.Ciudad.Id;
            pacienteActual.FechaNacimiento = paciente.FechaNacimiento;
            pacienteActual.Salario = paciente.Salario;
            pacienteActual.Telefono = paciente.Telefono;
            pacienteActual.Celular = paciente.Celular;
            pacienteActual.Titular = paciente.Titular;
            pacienteActual.IdSexo = paciente.Sexo.Id;

            contexto.SaveChanges();
        }

        public Paciente ObtenerPaciente(string numeroDocumento)
        {
            var pacienteActual = contexto.Pacientes.FirstOrDefault(p => p.NumeroDocumento == numeroDocumento);
            if (pacienteActual != null)
                return new Entidades.Paciente()
                {
                    PrimerNombre = pacienteActual.PrimerNombre,
                    SegundoNombre = pacienteActual.SegundoNombre,
                    PrimerApellido = pacienteActual.PrimerApellido,
                    SegundoApellido = pacienteActual.SegundoApellido,
                    NumeroDocumento = pacienteActual.NumeroDocumento,
                    TipoDocumento = new TipoDocumento() { Id = pacienteActual.TipoDocumento.Id },
                    Direccion = pacienteActual.Direccion,
                    Ciudad = new Ciudad()
                    {
                        Id = pacienteActual.Ciudad.Id,
                        Departamento = new Departamento()
                        {
                            Id = pacienteActual.Ciudad.IdDepartamento
                        }
                    },
                    FechaNacimiento = pacienteActual.FechaNacimiento,
                    Salario = pacienteActual.Salario,
                    Telefono = pacienteActual.Telefono,
                    Celular = pacienteActual.Celular,
                    Titular = pacienteActual.Titular,
                    Sexo = new Sexo() { Id = pacienteActual.Sexo.Id }
                };

            return null;
        }
    }
}