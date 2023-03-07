using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain;

namespace persistence.maps;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(x => x.CodigoCliente);

        builder.Property(x => x.CodigoCliente).HasColumnName("CodigoCliente");
        builder.Property(x => x.Nome).HasColumnName("Nome");
        builder.Property(x => x.Endereco).HasColumnName("Endereco");
        builder.Property(x => x.Cidade).HasColumnName("Cidade");
        builder.Property(x => x.UF).HasColumnName("UF");
        builder.Property(x => x.DataInsercao).HasColumnName("DataInsercao");     
    }
}
