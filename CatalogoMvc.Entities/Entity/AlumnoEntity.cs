
namespace CatalogoMvc.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AlumnoEntity
    {
        public int IdAlumno { get; set; }

        public int IdGrupo { get; set; }

        public string Nombre { get; set; }


        public short Edad { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        public DateTime? FechaNacimiento { get; set; }

        public string PadreTutor { get; set; }

        public string NombreProfesor { get; set; }

        public string NombreGrupo { get; set; }

    }
}
