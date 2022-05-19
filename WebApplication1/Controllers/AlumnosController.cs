namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.ILogic;
    using PagedList;

    public class AlumnosController : Controller
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

        #endregion Fields

        #region Constructor

        /// <summary>
        ///
        /// </summary>
        /// <param name="alumnoLogic"></param>
        public AlumnosController(IAlumnoLogic alumnoLogic, IGrupoLogic grupoLogic)
        {
            this.alumnoLogic = alumnoLogic;
            this.grupoLogic = grupoLogic;
        }

        #endregion Constructor

        // GET: Alumnos
        public async Task<ActionResult> Index()
        {
            await this.alumnoLogic.ObtieneAlumno(5);
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<ActionResult> _ListUser(int? page)
        {
            ICollection<AlumnoEntity> alumnos = null;

            try
            {
                alumnos = await this.alumnoLogic.ObtieneAlumnos();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            return PartialView(alumnos.ToPagedList(pageNumber, pageSize));
        }

        /// <summary>
        /// Crea un registro nuevo de alumno
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> _CreateUser()
        {
            AlumnoEntity alumno = new AlumnoEntity
            {
                Edad = 10
            };

            try
            {
                ViewBag.Grupos = await this.GetListaGrupos(-1);
            }
            catch (Exception)
            {
            }

            return PartialView(alumno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="grupos"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _CreateUser(AlumnoEntity alumno, List<int> grupos)
        {
            string message = string.Empty;

            try
            {
                if (alumno != null)
                {
                    if (alumno.Edad > 0)
                    {
                        alumno.IdGrupo = grupos[0];
                        if (await this.alumnoLogic.GuardaAlumno(alumno))
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
        public async Task<ActionResult> _EditUser(int id)
        {
            AlumnoEntity alumno = null;
            try
            {
                alumno = await this.alumnoLogic.ObtieneAlumno(id);
                ViewBag.Grupos = this.GetListaGrupos(alumno.IdGrupo);
            }
            catch (Exception ex)
            {

            }

            return PartialView(alumno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumno"></param>
        /// <param name="grupos"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> _EditUser(AlumnoEntity alumno, List<int> grupos)
        {
            string msg = string.Empty;

            try
            {
                alumno.IdGrupo = grupos[0];

                if (await this.alumnoLogic.ActualizaAlumno(alumno))
                {
                    msg = "ok";
                }
            }
            catch (Exception e)
            {
                msg = e.Message;
            }
            return Json(new { msg = msg }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Obtiene un listado de grupos
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        private async Task<ICollection<SelectListItem>> GetListaGrupos(int selected)
        {
            ICollection<SelectListItem> selectListItems = new List<SelectListItem>();

            try
            {
                ICollection<GrupoEntity> grupos = await this.grupoLogic.ObtieneGrupos();

                foreach (GrupoEntity grupo in grupos)
                {
                    SelectListItem item = new SelectListItem { Text = grupo.Nombre, Value = grupo?.IdGrupo.ToString() };
                    item.Selected = selected == grupo.IdGrupo;

                    selectListItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                //throw;
            }

            return selectListItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> _DeleteUser(int idAlumno)
        {
            string message = string.Empty;
            try
            {
                if (await this.alumnoLogic.EliminaAlumno(idAlumno))
                {
                    message = "ok";
                }
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return Json(new { msg = message }, JsonRequestBehavior.AllowGet);
        }
    }
}