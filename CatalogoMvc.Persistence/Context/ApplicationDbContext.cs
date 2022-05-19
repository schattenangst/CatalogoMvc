
namespace CatalogoMvc.Persistence.Context
{
    using System.Data.Entity;
    using System.Threading;
    using System.Threading.Tasks;
    using CatalogoMvc.Interfaces.IPersistence;
    using CatalogoMvc.Model;

    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(string connection)
            : base(connection)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Alumno> Alumno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Profesor> Profesor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Grupo> Grupo { get; set; }

        #region Methods

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Grupo>()
                .HasRequired(s => s.Profesor)
                .WithMany(s => s.Grupos)
                .HasForeignKey(g => g.IdProfesor);

            modelBuilder.Entity<Profesor>();

            modelBuilder.Entity<Alumno>()
                .HasRequired(s => s.Grupo)
                .WithMany(g => g.Alumnos)
                .HasForeignKey(f => f.IdGrupo);
        }
        #endregion
    }
}
