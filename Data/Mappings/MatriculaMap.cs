using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent.Data.Mappings;

public class MatriculaMap : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        //PK
        builder.HasKey(x => new { x.CursoId, x.UsuarioId })
            .HasName("PK_Matricula_Id");
        //Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //Propriedade
        builder.Property(x => x.CursoId)
            .IsRequired();
        builder.Property(x => x.UsuarioId)
            .IsRequired();
        builder.Property(x => x.DataMatricula)
            .IsRequired();

        //Index
        builder.HasIndex(x => x.DataMatricula)
            .HasDatabaseName("IX_Matricula_DataMatricula");

        //Relacionamento
        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Matriculas)
            .HasForeignKey("CursoId")
            .HasConstraintName("FK_Matricula_CursoId")
            //.OnDelete(DeleteBehavior.Cascade)
            ;
        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Matriculas)
            .HasForeignKey("UsuarioId")
            .HasConstraintName("FK_Matricula_UsuarioId");

    }
}