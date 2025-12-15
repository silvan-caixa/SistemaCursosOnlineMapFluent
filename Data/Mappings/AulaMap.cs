using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SistemaCursosOnlineMaoFluent;

public class AulaMap : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        //PK
        builder.HasKey(x => x.Id)
            .HasName("PK_Aula_Id");
        //IDENTITY
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        //PROPRIDADE
        builder.Property(x => x.Titulo)
            .HasColumnType("Varchar")
            .HasMaxLength(150)
            .IsRequired();
        builder.Property(x => x.UrlVideo)
            .HasColumnType("Varchar")
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(x => x.Ordem)
            .IsRequired();

        //INDEX
        builder.HasIndex(x => x.Titulo)
            .IsUnique();
        //RELACIONAMENTO
        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Aulas)
            .HasForeignKey(x => x.CursoId)
            .HasConstraintName("FK_CursoAula_CursoId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}