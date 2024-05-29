using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Risepay.Domain.Entities;
using Risepay.Infra.Maps.Base;


namespace Risepay.Infra.Maps
{
    public class ColaboradorMap : BaseDomainMap<Colaborador>
    {
        public ColaboradorMap() : base("tb_colaborador") { }

        public override void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(60).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(60).IsRequired();
            builder.Property(x => x.Telefone).HasColumnName("telefone");
            builder.HasOne(c => c.Cargo).WithMany().HasForeignKey(c => c.IdCargo).IsRequired();
        }
    }
}
