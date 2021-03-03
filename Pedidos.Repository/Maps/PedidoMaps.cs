using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class PedidoMaps: BaseDomainMaps<Pedido>
    {
        public PedidoMaps() : base("tbl_pedido") { }
        public override void Configure(EntityTypeBuilder<Pedido> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(x => x.valortotal).HasColumnName("valortotal").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.entrega).HasColumnName("entrega").IsRequired();
            //Adicionar Associação 1 para muitos
            builder.Property(x => x.clienteid).HasColumnName("clienteid").IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(x => x.Pedidos).HasForeignKey(x => x.clienteid);
        }
    }
}
