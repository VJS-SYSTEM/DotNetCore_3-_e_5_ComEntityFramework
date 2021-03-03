using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class EnderecoMaps: BaseDomainMaps<Endereco>
    {
        public EnderecoMaps() : base("tbl_endereco") { }
        public override void Configure(EntityTypeBuilder<Endereco> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.tipo).HasColumnName("tipo").IsRequired();
            builder.Property(x => x.logradouro).HasColumnName("logradouro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.bairro).HasColumnName("bairro").HasMaxLength(50).IsRequired();
            builder.Property(x => x.numero).HasColumnName("numero").HasMaxLength(10);
            builder.Property(x => x.complemento).HasColumnName("complemento").HasMaxLength(50);
            builder.Property(x => x.cep).HasColumnName("cep").HasMaxLength(8);

            //Adicionar Associação 1 para 1
            builder.HasOne(x => x.Cliente).WithOne(x => x.Endereco).HasForeignKey<Cliente>(x => x.enderecoid);
            //Adicionar Associação 1 para muitos
            builder.Property(x => x.cidadeid).HasColumnName("cidadeid").IsRequired();

            builder.HasOne(x => x.Cidade).WithMany().HasForeignKey(x => x.cidadeid);

        }
    }
}
