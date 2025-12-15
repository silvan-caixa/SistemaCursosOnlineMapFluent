using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent.Data.Mappings;

public class InstrutorMap : IEntityTypeConfiguration<Instrutor>
{
    public void Configure(EntityTypeBuilder<Instrutor> builder)
    {
        // PK
        builder.HasKey(x => x.Id)
            .HasName("PK_Instrutor_Id");
        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //Propriedade
        builder.Property(x => x.Nome)
            .HasColumnType("Varchar")
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(x => x.Bio)
            .HasColumnType("Varchar")
            .HasMaxLength(250)
            .IsRequired();
        builder.Property(x => x.DataCriacao)
            .HasColumnType("DateTime")
            .IsRequired();

        //Index

        //Relacionamento
    }
}