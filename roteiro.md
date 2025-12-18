# 1 ETAPA
# criar console OK

# Instalar pacote/Dependências: 
## "Microsoft.EntityFrameworkCore" Version="8.0" OK
## "Microsoft.EntityFrameworkCore.Design" Version="8.0" OK
## "Microsoft.EntityFrameworkCore.SqlServer" Version="8.0" OK

# Criar arquivo na raiz .gitignore OK
# Cria o projeto no git OK
# Cria uma branch para Mac OK

# cria pasta Data / 
## Cria arquivo DataContext OK
### Funcões: 
-- OnConfiguring OK, 
-- OnModelCreating OK, 
-- TestConexao OK. 
-- Propriedades: DbSet<Usuario>. Herança: : DbContext
## Criar past Mapping OK /
### Criar os arquivos do modelo: CursoMap.cs, AlunoMap.cs ... OK
#### class: PostMap : IEntityTypeConfiguration<Post>, Funcoesclear: Configure OK
##### Table: ToTable. FK:HasKey. Propriedade:Property. Index:HasIndex. Relacionamento: HasOne,HasMany OK

# 2 ETAPA
# Criar pasta Models OK
## Criar os arquivos: Curso, Aluno OK

# 3 ETAPA
# Cria a migrations OK
### Terminal
- Comando não funciona
-- dotnet tool install --global donet-ef
- verifica instalação
-- dotnet ef
- Limpa toda solução
-- dotnet clear
- Copilar aplicação
-- dotnet build
- cria/alteração a migração 
-- dotnet ef migrations add InitialCreate
- Remover migração 
-- dotnet ef migrations remove InitialCreate
- Cria as tabelas no banco
-- dotnet ef database update
- Cria um script para executa direta no banco
-- dotnet ef migrations script -o ./script.sql

# 4 ETAPA IMPLEMENTAR REGRA DE NEGOCIO
# 🧾 1. Escopo
Sistema onde:
- Instrutores criam cursos
- Usuários consomem aulas
- Usuários avaliam cursos
- Cursos pertencem a categorias
# 🧩 2. Regras de Negócio
- RN01: Instrutor só edita seus cursos  
- RN02: Usuário só pode avaliar curso matriculado  
- RN03: Curso publicado só após ter aula  
- RN04: Matrícula é única (UsuarioId + CursoId)  
- RN05: Nota de avaliação entre 1 e 5 
# 🔗 4. Relacionamentos
- Instrutor 1:N Curso  
- Categoria 1:N Curso  
- Curso 1:N Aula  
- Usuario N:N Curso (via Matricula)  
- Curso 1:N Avaliacao  
- Usuario 1:N Avaliacao  

## Implementação
- CRUD Usuario e Instrutor (Create ok, Read ok, Remove e Update)
