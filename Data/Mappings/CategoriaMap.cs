using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCursosOnlineMaoFluent.Data.Mappings;

public class CategoriaMap : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        //PK
        builder.HasKey(x => x.Id)
            .HasName("FK_Categoria_Id");
        //Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        //Propriedade
        builder.Property(x => x.Nome)
            .HasColumnType("Varchar")
            .HasMaxLength(60)
            .IsRequired();
        //Index
        builder.HasIndex(x => x.Nome)
            .IsUnique();
        //Relacionamento

    }
}