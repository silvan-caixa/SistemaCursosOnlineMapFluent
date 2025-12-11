using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("USUARIO", "SCO");
        //PK
        builder.HasKey(x => x.Id)
            .HasName("PK_Usuario_Id");
        //IDENTITY
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        //PROPRIEDADE
        builder.Property(x => x.Nome)
            .HasColumnType("Varchar")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Email)
            .HasColumnType("Varchar")
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.SenhaHash)
            .IsRequired();
        builder.Property(x => x.DataCadastro)
            .IsRequired();

        //INDEX
        builder.HasIndex(x => x.Email)
            .IsUnique();
        //RELACIONAMENTO
    }
}