
namespace CatalogoMvc.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("GrupoProfesor")]
    public class GrupoProfesor_
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdGrupo { get; set; }

        [Required]
        public int IdProfesor { get; set; }

        [Required]
        public bool Activo { get; set; }

        public virtual Profesor Profesor { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
