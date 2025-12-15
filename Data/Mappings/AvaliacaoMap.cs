using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent.Data.Mappings;

public class AvaliacaoMap : IEntityTypeConfiguration<Avaliacao>
{
    public void Configure(EntityTypeBuilder<Avaliacao> builder)
    {
        builder.HasKey(x => x.Id)
            .HasName("PK_Avaliacao_Id");
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.UsuarioId)
            .IsRequired();
        builder.Property(x => x.CursoId)
            .IsRequired();
        builder.Property(x => x.Nota)
            .IsRequired();
        builder.Property(x => x.Comentario)
            .HasColumnType("Varchar")
            .HasMaxLength(Avaliacao.ComentarioMaxLength);
        builder.Property(x => x.DataAvaliacao)
            .IsRequired();
        //Index
        builder.HasIndex(x => new { x.CursoId, x.UsuarioId })
            .IsUnique();
        //Relacionamento
        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Avaliacoes)
            .HasForeignKey("FK_Avaliacao_UsuarioId")
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Avaliacoes)
            .HasForeignKey("FK_Avaliacao_CursoId")
            .OnDelete(DeleteBehavior.Cascade);

    }
}