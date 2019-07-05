using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace WebLecturaInteractiva.Models
{
    public class WebLecturaInteractivaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public WebLecturaInteractivaContext() : base("name=WebLecturaInteractivaContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<CategoriaLectura> CategoriaLectura { get; set; }
        public DbSet<NivelPregunta> NivelPregunta { get; set; }
        public DbSet<TipoPreguntas> TipoPreguntas { get; set; }
        public DbSet<Lectura> Lectura { get; set; }
        public DbSet<SubCategoriaLectura> SubCategoriaLectura { get; set; }
        public DbSet<DetalleModoLecturaXLectura> DetalleModoLecturaXLectura { get; set; }
        public DbSet<ModoLectura> ModoLectura { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TipoPersonas> TipoPersonas { get; set; }
    }
}