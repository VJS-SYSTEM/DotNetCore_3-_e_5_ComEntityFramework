using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class ClienteMaps: BaseDomainMaps<Cliente>
    {
        public ClienteMaps() : base("tbl_cliente") { }
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
            builder.Property(x => x.cpf).HasColumnName("cpf").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ativo).HasColumnName("ativo").IsRequired();
            //Adicionar Associação 1 para 1
            builder.Property(x => x.enderecoid).HasColumnName("enderecoid").IsRequired();

        }
    }
}
