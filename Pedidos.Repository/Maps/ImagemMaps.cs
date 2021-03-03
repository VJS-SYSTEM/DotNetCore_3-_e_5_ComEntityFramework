using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class ImagemMaps: BaseDomainMaps<Imagem>
    {
        public ImagemMaps() : base("tbl_imagem") { }
        public override void Configure(EntityTypeBuilder<Imagem> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(20).IsRequired();
            builder.Property(x => x.nomearquivo).HasColumnName("nomearquivo").HasMaxLength(20).IsRequired();
            builder.Property(x => x.principal).HasColumnName("principal").IsRequired();

        }
    }
}
