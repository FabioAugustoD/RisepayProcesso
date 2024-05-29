using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Risepay.Domain.Entities;
using Risepay.Infra.Maps.Base;


namespace Risepay.Infra.Maps
{
    public class CargoMap : BaseDomainMap<Cargo>
    {
        public CargoMap() : base("tb_cargo") { }

        public override void Configure(EntityTypeBuilder<Cargo> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(40).IsRequired();
        }
            
    }
}