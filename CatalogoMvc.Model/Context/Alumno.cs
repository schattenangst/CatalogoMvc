
namespace CatalogoMvc.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Alumno")]
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }

        [Required]
        public int IdGrupo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public short Edad { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string PadreTutor { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
