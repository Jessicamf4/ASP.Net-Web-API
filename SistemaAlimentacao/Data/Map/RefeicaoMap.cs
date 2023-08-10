using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaAlimentacao.Models;

namespace SistemaAlimentacao.Data.Map
{
    public class RefeicaoMap : IEntityTypeConfiguration<RefeicaoModel>
    {
        public void Configure(EntityTypeBuilder<RefeicaoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(150);
            builder.Property(x => x.TipoRefeicao).IsRequired();
            builder.Property(x => x.Calorias).IsRequired();
        }
    }
}
