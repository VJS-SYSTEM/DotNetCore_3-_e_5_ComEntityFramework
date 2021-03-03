using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class ProdutoPedidoMaps : BaseDomainMaps<ProdutoPedido>
    {
        public ProdutoPedidoMaps() : base("tbl_produto_pedido") { }
        public override void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.quantidade).HasColumnName("quantidade").HasPrecision(2).IsRequired();
            builder.Property(x => x.preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            //Adicionar Associação muitos para muitos
            builder.Property(x => x.pedidoid).HasColumnName("pedidoid").IsRequired();
            builder.HasOne(x => x.Pedido).WithMany(x => x.Produto).HasForeignKey(x => x.pedidoid);

            builder.Property(x => x.produtoid).HasColumnName("produtoid").IsRequired();
            builder.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.produtoid);
        }
    }
}
