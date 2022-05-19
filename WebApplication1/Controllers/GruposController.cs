namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.ILogic;
    using PagedList;

    public class GruposController : Controller
    {
        #region Fields

        /// <summary>
        /// Dependencia de clase
        /// </summary>
        private readonly IAlumnoLogic alumnoLogic;

        /// <summary>
        /// Dependencia de clase
        /// </summary>
        private readonly IGrupoLogic grupoLogic;

        /// <summary>
        /// 
        /// </summary>
        private readonly IProfesorLogic profesorLogic;

        #endregion Fields

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="alumnoLogic"></param>
        public GruposController(IAlumnoLogic alumnoLogic, IGrupoLogic grupoLogic, IProfesorLogic profesorLogic)
        {
            this.alumnoLogic = alumnoLogic;
            this.grupoLogic = grupoLogic;
            this.profesorLogic = profesorLogic;
        }

        #endregion Constructor

        // GET: Alumnos
        public async Task<ActionResult> Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<ActionResult> _ListGroup(int? page)
        {
            ICollection<GrupoEntity> grupos = null;

            try
            {
                grupos = await this.grupoLogic.ObtieneGrupoProfesor();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            return PartialView(grupos.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Crea un registro nuevo de alumno
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> _CreateGroup()
        {
            GrupoEntity grupoNuevo = new GrupoEntity();

            try
            {
                ViewBag.Profesores = this.GetListaProfesores(-1, false);
            }
            catch (Exception)
            {
            }

            return PartialView(grupoNuevo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="profesores"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _CreateGroup(GrupoEntity grupo, List<int> profesores)
        {
            string message = string.Empty;

            try
            {
                if (grupo != null)
                {
                    if (profesores.Count > 0)
                    {
                        grupo.IdProfesor = profesores[0];
                        if (await this.grupoLogic.CrearGrupo(grupo))
                        {
                            message = "ok";
                        }
                    }
                    else
                    {
                        message = "La edad no es correcta";
                    }
                }
            }
            catch (Exception e)
            {
            }

            return Json(new { message }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> _EditGroup(int id)
        {
            GrupoEntity grupo = null;
            try
            {
                grupo = await this.grupoLogic.ObtieneGrupo(id);
                ViewBag.Profesores = this.GetListaProfesores(grupo.IdGrupo, true);
            }
            catch (Exception ex)
            {

            }

            return PartialView(grupo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grupo"></param>
        /// <param name="grupos"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _EditGroup(GrupoEntity grupo, List<int> profesores)
        {
            string msg = string.Empty;

            try
            {
                grupo.IdProfesor = profesores[0];
                if (await this.grupoLogic.ActualizaGrupo(grupo))
                {
                    msg = "ok";
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }

            return Json(new { msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene un listado de grupos
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        private async Task<ICollection<SelectListItem>> GetListaProfesores(int selected, bool edit)
        {
            ICollection<SelectListItem> selectListItems = new List<SelectListItem>();

            try
            {
                ICollection<ProfesorEntity> grupos = this.profesorLogic.ObtieneProfesores(edit);

                foreach (ProfesorEntity profesor in grupos)
                {
                    SelectListItem item = new SelectListItem { Text = profesor.Nombre, Value = profesor.IdProfesor.ToString() };

                    item.Selected = selected == profesor.IdProfesor;

                    selectListItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return selectListItems;
        }
    }
}