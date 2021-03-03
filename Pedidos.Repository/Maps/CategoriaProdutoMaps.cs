using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class CategoriaProdutoMaps : BaseDomainMaps<CategoriaProduto>
    {
        public CategoriaProdutoMaps() : base("tbl_categoria_produto") { }
        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ativo).HasColumnName("ativo").IsRequired();
        }
    }
}
