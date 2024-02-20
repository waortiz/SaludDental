using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set;}
        public string PrimerApellido { get; set;}
        public string SegundoApellido { get; set; }
        public int IdTipoDocumento { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Titular { get; set; }
        public string Telefono { get; set; }
        public string Direcion { get; set; }
        public decimal Salario { get; set; }
        public int IdCiudad { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public int IdSexo { get; set; }
        public virtual Sexo Sexo { get; set; }
    }
}
