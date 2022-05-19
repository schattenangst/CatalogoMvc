
namespace CatalogoMvc.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int IdProfesor { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool Activo { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}
