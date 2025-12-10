# Atividade de Modelagem de Dados – Mini Sistema de Cursos Online (Fluent API)

## 🎯 Objetivo
Praticar:
- Modelagem conceitual e lógica
- Relacionamentos
- Normalização
- SQL
- Entidades .NET sem DataAnnotations
- Mapeamento usando Fluent API
- Configuração do DataContext + Migrations

---

# 📘 1. Contexto do Sistema
Sistema educacional simples:
- Instrutores criam cursos
- Cursos possuem aulas
- Usuários se matriculam
- Usuários avaliam cursos
- Cursos pertencem a categorias

---

# 🧱 2. Entidades
- Usuario
- Instrutor
- Categoria
- Curso
- Aula
- Matricula
- Avaliacao

> As entidades **não têm DataAnnotations**.

---

# 🧩 3. Exemplo de Entidade SEM DataAnnotations

```csharp
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
    public ICollection<Avaliacao> Avaliacoes { get; set; }
}
```

---

# 🔧 4. Exemplo de Mapping Fluent API

Crie uma pasta:

```
Data/Mappings/
```

### **UsuarioMap.cs**
```csharp
public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("USUARIO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Nome)
            .HasColumnName("NOME")
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("varchar(100)")
            .IsRequired();
    }
}
```

---

# 🧩 5. Modelo Físico (SQL) – Exemplo
```sql
CREATE TABLE USUARIO (
    Id INT IDENTITY PRIMARY KEY,
    NOME VARCHAR(100),
    EMAIL VARCHAR(100)
);
```

---

# 🏗 6. DataContext com Fluent API

```csharp
public class AppDataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Curso> Cursos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new CursoMap());
        modelBuilder.ApplyConfiguration(new CategoriaMap());
        modelBuilder.ApplyConfiguration(new AulaMap());
        modelBuilder.ApplyConfiguration(new MatriculaMap());
        modelBuilder.ApplyConfiguration(new AvaliacaoMap());
    }
}
```

---

# 🚀 7. Migrations
```
dotnet ef migrations add Initial
dotnet ef database update
```

---

# 🎁 Resultado
O aluno deve entregar:
- Entidades sem DataAnnotations
- Mappings Fluent API completos
- Diagramas ER
- SQL de criação
- Contexto configurado
- Migrations aplicadas
