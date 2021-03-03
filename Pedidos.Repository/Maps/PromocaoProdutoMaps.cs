using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;

namespace Pedidos.Repository
{
    public class PromocaoProdutoMaps : BaseDomainMaps<PromocaoProduto>
    {
        public PromocaoProdutoMaps() : base("tbl_promocao_produto") { }
        public override void Configure(EntityTypeBuilder<PromocaoProduto> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.nome).HasColumnName("nome").HasMaxLength(50).IsRequired();
            builder.Property(x => x.preco).HasColumnName("preco").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.ativo).HasColumnName("ativo").IsRequired();

            //Adicionar Associação 1 para muitos
            builder.Property(x => x.imagemid).HasColumnName("imagemid").IsRequired();
            builder.HasOne(x => x.Imagem).WithMany().HasForeignKey(x => x.imagemid);

            //Adicionar Associação 1 para muitos
            builder.Property(x => x.produtoid).HasColumnName("produtoid").IsRequired();
            builder.HasOne(x => x.Produto).WithMany(x => x.PromocaoProdutos).HasForeignKey(x => x.produtoid);

        }
    }
}
