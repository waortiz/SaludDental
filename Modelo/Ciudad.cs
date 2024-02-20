using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo
{
    [Table("Ciudades")]
    public class Ciudad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }
        
        public virtual Departamento Departamento { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}