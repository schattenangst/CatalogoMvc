
namespace CatalogoMvc.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Grupo")]
    public class Grupo
    {
        [Key]
        public int IdGrupo { get; set; }

        public int IdProfesor { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int NumeroAlumnos { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }

        public virtual Profesor Profesor { get; set; }
    }
}
