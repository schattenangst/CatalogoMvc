namespace CatalogoMvc.Logic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CatalogoMvc.Entities;
    using CatalogoMvc.Interfaces.ILogic;
    using CatalogoMvc.Interfaces.IPersistence;

    public class AlumnoLogic : IAlumnoLogic
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private readonly IAlumnoRepository alumnoRepository;

        /// <summary>
        /// 
        /// </summary>
        private readonly IApiServices apiServices;

        #endregion

        #region Contructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alumnoRepository"></param>
        /// <param name="apiServices"></param>
        public AlumnoLogic(IAlumnoRepository alumnoRepository, IApiServices apiServices)
        {
            this.alumnoRepository = alumnoRepository;
            this.apiServices = apiServices;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Obtiene registros de alumnos
        /// </summary>
        /// <returns>Coleccion de alumnos</returns>
        public async Task<ICollection<AlumnoEntity>> ObtieneAlumnos()
        {
            ICollection<AlumnoEntity> alumnos = null;

            try
            {
                ResponseMessage<IEnumerable<StudentEntity>> responseStudents = null;
                responseStudents = await apiServices.GetRequest<IEnumerable<StudentEntity>>(new Uri("http://localhost:8000/students"));

                if (responseStudents.Response != null && responseStudents.Response.Count() > 0)
                {
                    alumnos = new List<AlumnoEntity>();
                    foreach (StudentEntity item in responseStudents.Response)
                    {
                        alumnos.Add(new AlumnoEntity
                        {
                            Edad = (short)item.Age,
                            Nombre = item.Name,
                            FechaNacimiento = item.Birthday,
                            PadreTutor = item.Tutor,
                            IdAlumno = item.Id
                        });
                    }
                }

                // alumnos = this.alumnoRepository.ObtieneAlumnos();
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        /// <summary>
        /// Obtiene el registro de un alumno
        /// </summary>
        /// <param name="idAlumno"></param>
        /// <returns>Coleccion de alumnos</returns>
        public async Task<AlumnoEntity> ObtieneAlumno(int idAlumno)
        {
            AlumnoEntity alumno = null;

            try
            {
                ResponseMessage<StudentEntity> responseStudents = null;
                responseStudents = await apiServices.GetRequest<StudentEntity>(new Uri(string.Format("http://localhost:8000/student/{0}", idAlumno)));

                if (responseStudents.Response != null)
                {
                    alumno = new AlumnoEntity
                    {
                        Edad = (short)responseStudents.Response.Age,
                        Nombre = responseStudents.Response.Name,
                        FechaNacimiento = responseStudents.Response.Birthday,
                        PadreTutor = responseStudents.Response.Tutor,
                        IdAlumno = responseStudents.Response.Id
                    };
                }

                // alumno = this.alumnoRepository.ObtieneAlumno(idAlumno);
            }
            catch (Exception)
            {

                throw;
            }

            return alumno;
        }

        /// <summary>
        /// Realiza el registro de un nuevo alumno
        /// </summary>
        /// <param name="alumno">Objeto con datos de <see cref="AlumnoEntity"/></param>
        /// <returns>True operación correcta</returns>
        public async Task<bool> GuardaAlumno(AlumnoEntity alumno)
        {
            bool estatus = false;

            try
            {
                if (alumno != null)
                {
                    /*
                    Alumno nuevoAlumno = new Alumno
                    {
                        Nombre = alumno.Nombre,
                        Edad = alumno.Edad,
                        FechaNacimiento = (DateTime)alumno.FechaNacimiento,
                        PadreTutor = alumno.PadreTutor,
                        IdGrupo = alumno.IdGrupo,
                    };
                    */

                    StudentEntity newStudent = new StudentEntity
                    {
                        Name = alumno.Nombre,
                        Surname = "apellido default",
                        Age = alumno.Edad,
                        IdGroup = alumno.IdGrupo,
                        Birthday = (DateTime)alumno.FechaNacimiento,
                        Tutor = alumno.PadreTutor
                    };

                    ResponseMessage<bool> result = await this.apiServices.PostRequest(new Uri("http://localhost:8000/student"), newStudent);
                    estatus = result.Response;
                    // estatus = this.alumnoRepository.GuardaAlumno(nuevoAlumno);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return estatus;
        }

        /// <summary>
        /// Actualiza información de un alumno
        /// </summary>
        /// <param name="alumno">Objeto con datos de <see cref="AlumnoEntity"/></param>
        /// <returns>True operación correcta</returns>
        public async Task<bool> ActualizaAlumno(AlumnoEntity alumno)
        {
            bool estatus = false;

            try
            {
                if (alumno != null)
                {
                    //Alumno nuevoAlumno = new Alumno
                    //{
                    //    Nombre = alumno.Nombre,
                    //    Edad = alumno.Edad,
                    //    FechaNacimiento = (DateTime)alumno.FechaNacimiento,
                    //    PadreTutor = alumno.PadreTutor,
                    //    IdGrupo = alumno.IdGrupo,
                    //};

                    StudentEntity updateStudent = new StudentEntity
                    {
                        Name = alumno.Nombre,
                        Surname = "apellido default",
                        Age = alumno.Edad,
                        IdGroup = alumno.IdGrupo,
                        Birthday = (DateTime)alumno.FechaNacimiento,
                        Tutor = alumno.PadreTutor
                    };

                    estatus = (await this.apiServices.PutRequest(new Uri(string.Format("http://localhost:8000/student/{0}", alumno.IdAlumno)), updateStudent)).Response;
                }
            }
            catch (Exception)
            {

            }


            return estatus;
        }

        /// <summary>
        /// Elimina información de un alumno
        /// </summary>
        /// <param name="idAlumno">Identificador de alumno</param>
        /// <returns>True operación correcta</returns>
        public async Task<bool> EliminaAlumno(int idAlumno)
        {
            bool estatus = false;

            try
            {
                estatus = this.alumnoRepository.EliminaAlumno(idAlumno);
            }
            catch (Exception)
            {

                throw;
            }

            return estatus;
        }

        #endregion
    }
}
