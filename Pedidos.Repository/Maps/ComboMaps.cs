using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class ComboMaps: BaseDomainMaps<Combo>
    {
        public ComboMaps() : base("tbl_combo") { }
        public override void Configure(EntityTypeBuilder<Combo> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.ativo).HasColumnName("ativo").IsRequired();
            //Adicionar Associação 1 para muitos
            builder.Property(x => x.imagemid).HasColumnName("imagemid").IsRequired();
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.imagemid);

            //Adicionar Associação muitos para muitos
            builder
                .HasMany(x => x.Produto)
                .WithMany(x => x.Combos)
                .UsingEntity<ProdutoCombo>(
                x => x.HasOne( f => f.Produto).WithMany().HasForeignKey(f => f.produtoid),
                x => x.HasOne(f => f.Combos).WithMany().HasForeignKey(f => f.comboid),
                x =>
                {
                    x.ToTable("tbl_produto_combo");
                    x.HasKey(s => new { s.produtoid, s.comboid });
                    x.Property(x => x.produtoid).HasColumnName("produtoid").IsRequired();
                    x.Property(x => x.comboid).HasColumnName("comboid").IsRequired();
                });
        }
    }
}
