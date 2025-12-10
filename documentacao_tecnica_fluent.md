# Documentação Técnica Completa – Sistema de Cursos Online (Fluent API)

## 📌 Sumário
- Escopo
- Regras de negócio
- Modelo conceitual
- Modelo lógico
- Modelo físico SQL
- Entidades C#
- Mapeamento Fluent API
- DataContext
- Teste de conexão

---

# 🧾 1. Escopo
Sistema onde:
- Instrutores criam cursos
- Usuários consomem aulas
- Usuários avaliam cursos
- Cursos pertencem a categorias

---

# 🧩 2. Regras de Negócio
- RN01: Instrutor só edita seus cursos  
- RN02: Usuário só pode avaliar curso matriculado  
- RN03: Curso publicado só após ter aula  
- RN04: Matrícula é única (UsuarioId + CursoId)  
- RN05: Nota de avaliação entre 1 e 5  

---

# 🧱 3. Modelo Conceitual
Entidades:
Usuario, Instrutor, Categoria, Curso, Aula, Matricula, Avaliacao.

---

# 🔗 4. Relacionamentos
- Instrutor 1:N Curso  
- Categoria 1:N Curso  
- Curso 1:N Aula  
- Usuario N:N Curso (via Matricula)  
- Curso 1:N Avaliacao  
- Usuario 1:N Avaliacao  

---

# 🗃 5. Modelo Lógico – Exemplo: Curso
| Campo | Tipo |
|-------|------|
| Id | INT |
| Titulo | VARCHAR(150) |
| Descricao | VARCHAR(MAX) |
| CategoriaId | INT |
| InstrutorId | INT |

---

# 🧩 6. SQL – Tabela Curso
```sql
CREATE TABLE CURSO (
    Id INT IDENTITY PRIMARY KEY,
    TITULO VARCHAR(150),
    DESCRICAO VARCHAR(MAX),
    CategoriaId INT,
    InstrutorId INT,
    DataCriacao DATETIME DEFAULT GETDATE()
);
```

---

# 🖥 7. Entidade C# – SEM DataAnnotations
```csharp
public class Curso
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }

    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }

    public int InstrutorId { get; set; }
    public Instrutor Instrutor { get; set; }
}
```

---

# 🔧 8. Mapping Fluent API – CursoMap
```csharp
public class CursoMap : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("CURSO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Titulo)
            .HasColumnName("TITULO")
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("DESCRICAO")
            .HasColumnType("varchar(max)");

        builder.HasOne(x => x.Categoria)
            .WithMany()
            .HasForeignKey(x => x.CategoriaId);

        builder.HasOne(x => x.Instrutor)
            .WithMany()
            .HasForeignKey(x => x.InstrutorId);
    }
}
```

---

# 🏗 9. DataContext
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfiguration(new UsuarioMap());
    modelBuilder.ApplyConfiguration(new CursoMap());
    modelBuilder.ApplyConfiguration(new CategoriaMap());
    modelBuilder.ApplyConfiguration(new AulaMap());
    modelBuilder.ApplyConfiguration(new MatriculaMap());
    modelBuilder.ApplyConfiguration(new AvaliacaoMap());
}
```

---

# 🧪 10. Teste de Conexão
```csharp
using var db = new AppDataContext();
Console.WriteLine(db.Database.CanConnect() ? "OK" : "Falha");
```

---

# 🚀 11. Extensões Futuras
- Certificados  
- Comentários nas aulas  
- Progresso de visualização  
- Histórico de avaliações  
- Cupons  

