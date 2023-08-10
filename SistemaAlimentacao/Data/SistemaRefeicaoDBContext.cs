using Microsoft.EntityFrameworkCore;
using SistemaAlimentacao.Data.Map;
using SistemaAlimentacao.Models;

namespace SistemaAlimentacao.Data
{
    public class SistemaRefeicaoDBContext : DbContext
    {
        public SistemaRefeicaoDBContext(DbContextOptions<SistemaRefeicaoDBContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<RefeicaoModel> Refeicao { get; set;}
    
        protected override void OnModelCreating(ModelBuilder modelBulder)
        {
            modelBulder.ApplyConfiguration(new UsuarioMap());
            modelBulder.ApplyConfiguration(new RefeicaoMap());
            base.OnModelCreating(modelBulder);
        }
    }
}
