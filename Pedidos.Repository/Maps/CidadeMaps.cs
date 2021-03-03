using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class CidadeMaps : BaseDomainMaps<Cidade>
    {
        public CidadeMaps() : base("tbl_cidade") { }
        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.uf).HasColumnName("uf").HasMaxLength(2).IsRequired();
            builder.Property(x => x.ativo).HasColumnName("ativo").IsRequired();

        }
    }
}
