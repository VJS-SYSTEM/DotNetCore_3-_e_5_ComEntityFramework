using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain;


namespace Pedidos.Repository
{
   public class BaseDomainMaps<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseDomain
    {
        private readonly string _tableName;

        public BaseDomainMaps(string tableName = "")
        {
            _tableName = tableName;
        }


        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!string.IsNullOrEmpty(_tableName))
            {
                builder.ToTable(_tableName);
            }

            builder.HasKey( x => x.id);
            builder.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.criadoem).HasColumnName("criadoem").IsRequired();
        }
    }
}
