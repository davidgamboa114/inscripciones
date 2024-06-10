using Microsoft.EntityFrameworkCore;
using Inscripciones.Models;

namespace Inscripciones.Models
{
    public class InscripcionesContext : DbContext
    {
        public InscripcionesContext(DbContextOptions<InscripcionesContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;      
            //                   Database=InscripcionesContext;
            //                   User Id = sa; Password = 123; Encrypt=false");
            //string cadenaConexion = "Server=127.0.0.1;Database=inscripcionescontext; User=root;Password=;";
            //optionsBuilder.UseMySql
            //    (cadenaConexion,
            //    ServerVersion.AutoDetect
            //    (cadenaConexion));
            string cadenaConexion = "Server=5.57.213.17;Database=smartsof_davidgamboa; User=smartsof_gamboa;Password=gamboadavid123";
            optionsBuilder.UseMySql
                (cadenaConexion,
                ServerVersion.AutoDetect
                (cadenaConexion));
        }
        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Carrera> Carreras { get; set; }
        public virtual DbSet<Inscripcion> Inscripciones { get; set; }
        public virtual DbSet<AnioCarrera> AnioCarrera { get; set; }
        public virtual DbSet<DetalleInscripciones> DetalleInscripciones { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
    }

}