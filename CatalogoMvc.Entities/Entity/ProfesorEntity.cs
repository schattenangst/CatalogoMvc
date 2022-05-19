
namespace CatalogoMvc.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProfesorEntity
    {
        public int IdProfesor { get; set; }

        public string Nombre { get; set; }

        public bool Activo { get; set; }
    }
}
