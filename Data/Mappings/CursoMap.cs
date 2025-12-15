using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent;

public class CursoMap : IEntityTypeConfiguration<Curso>
{
    public int DescricaoMaxLength { get; private set; }

    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        // PK
        builder.HasKey(x => x.Id)
            .HasName("PK_Curso_Id");
        //IDENTITY
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        //PROPRIEDADE
        builder.Property(x => x.Titulo)
            .HasColumnType("Varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnType("Varchar")
            .HasMaxLength(Curso.DescricaoMaxLength)
            .IsRequired();

        builder.Property(x => x.CategoriaId)
            .IsRequired();

        builder.Property(x => x.CategoriaId)
            .IsRequired();

        builder.Property(x => x.DataCriacao)
            .IsRequired();
        //INDEX

        //RELACIONAMENTO
        builder.HasOne(x => x.Instrutor)
            .WithMany(x => x.Cursos)
            .HasForeignKey(x => x.InstrutorId)
            .HasConstraintName("FK_CursoIntrutor_InstrutorId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.Cursos)
            .HasForeignKey(x => x.CategoriaId)
            .HasConstraintName("FK_CursoCategoria_CategoriaId")
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
        // builder.HasMany(x=>x.Usuarios)
        //     .HasMany(x=>x.Cursos)
        //     .UseIdentityColumn<Dictionary<string, object>>(
        //         "CursoUsuario", 
        //         curso => curso.HasOne()
        //             .HasMany()
        //             .HasForeignKey("CursoId")
        //             .HasConstraintName("FK_CursoUsuario_CursoId"),
        //         usuario => usuario.HasOne()
        //             .HasMany()
        //             .HasForeignKey("UsuarioId")
        //             .HasConstraintName("FK_CursoUsuario_UsuarioId"),
        //         dataCadastro => dataCadastro.Property(x=>x.DataCadastro)
        //             .HasColumnType("DateTime")
        //             .HasName();
                    
        //     );
    }
}