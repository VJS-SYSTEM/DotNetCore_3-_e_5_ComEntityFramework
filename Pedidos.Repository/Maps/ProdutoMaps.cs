using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class ProdutoMaps: BaseDomainMaps<Produto>
    {
        public ProdutoMaps() : base("tbl_produto") { }
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.codigo).HasColumnName("codigo").HasMaxLength(50).IsRequired();
            builder.Property(x => x.descricao).HasColumnName("descricao").HasMaxLength(100).IsRequired();
            builder.Property(x => x.preco).HasColumnName("preco").HasPrecision(17,2).IsRequired();
            builder.Property(x => x.ativo).HasColumnName("ativo").IsRequired();

            //Adicionar Associação 1 para muitos
            builder.Property(x => x.categoriaid).HasColumnName("categoriaid").IsRequired();
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos).HasForeignKey(x => x.categoriaid);

            //Adicionar Associação muitos para muitos
            builder
                .HasMany(x => x.Imagens)
                .WithMany(x => x.Produtos)
                .UsingEntity<ImagemProduto>(
                x => x.HasOne(f => f.Imagens).WithMany().HasForeignKey(f => f.imagemid),
                x => x.HasOne(f => f.Produtos).WithMany().HasForeignKey(f => f.produtoid),
                x =>
                {
                    x.ToTable("tbl_imagem_produto");
                    x.HasKey(s => new { s.imagemid, s.produtoid });
                    x.Property(x => x.produtoid).HasColumnName("produtoid").IsRequired();
                    x.Property(x => x.imagemid).HasColumnName("imagemid").IsRequired();
                });
        }
    }
}
