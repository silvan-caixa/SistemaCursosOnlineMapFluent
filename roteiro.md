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