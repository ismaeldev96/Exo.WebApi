using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;


namespace Exo.WebApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext()
        {

        }
        public ExoContext(DbContextOptions<ExoContext>options) : base(options)
        {

        }

        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-7S1TGCM\\SQLEXPRESS1;initial catalog = ExoDB; User Id=sa; password=1234");
            }
        }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<ProjetoUsuario> UsuarioProjeto { get; set; }
    }
}
