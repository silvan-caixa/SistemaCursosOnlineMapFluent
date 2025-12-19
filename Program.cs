// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.Common;
using SistemaCursosOnlineMaoFluent.Data;
using SistemaCursosOnlineMaoFluent.Models;

namespace SistemaCursosOnlineMaoFluent;

public class Program
{
    private static DataContext db = new DataContext();

    public static void Main()
    {
        //DataContext.TestConection();

        bool emExecucao = true;

        while (emExecucao)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE CADASTRO 2025 ===");
            Console.WriteLine("1. Criar Usuário");
            Console.WriteLine("2. Criar Instrutor");
            Console.WriteLine("3. Editar Usuario");
            Console.WriteLine("4. Editar Instrutor");
            Console.WriteLine("5. Deletar Usuario");
            Console.WriteLine("6. Deletar Instrutor");
            Console.WriteLine("7. Listar Usuario");
            Console.WriteLine("8. Listar Instrutor");
            Console.WriteLine("9. Instrutores criam cursos");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            string opcao = Console.ReadLine()!;

            switch (opcao)
            {
                case "1":
                    CriarUsuario();
                    break;
                case "2":
                    CriarInstrutor();
                    break;
                case "3":
                    EditarUsuario();
                    break;
                case "4":
                    EditarInstrutor();
                    break;
                case "5":
                    DeletarUsuario();
                    break;
                case "6":
                    DeletarInstrutor();
                    break;
                case "7":
                    ListarUsuario();
                    break;
                case "8":
                    ListarInstrutor();
                    break;
                case "9":
                    InstrutorCriarCurso();
                    break;
                case "0":
                    Console.WriteLine("Saindo do sistema...");
                    emExecucao = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                    Console.ReadKey();
                    break;
            }
            static void CriarUsuario()
            {
                Console.Clear();
                Console.WriteLine("--- Cadastro de Usuário ---");
                Console.Write("Digite o nome do usuário: ");
                string nome = Console.ReadLine()!;
                Console.Write("Digite o Email: ");
                string email = Console.ReadLine()!;
                Console.Write("Digite a Senha: ");
                string senha = Console.ReadLine()!;

                // Lógica de salvamento aqui
                var usuario = new Usuario { Nome = nome, Email = email, SenhaHash = senha };
                db.Usuarios.Add(usuario);
                db.SaveChanges();

                Console.WriteLine($"\nUsuário '{nome}' criado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
            }

            static void CriarInstrutor()
            {
                Console.Clear();
                Console.WriteLine("--- Cadastro de Instrutor ---");
                Console.Write("Digite o nome do instrutor: ");
                string nome = Console.ReadLine()!;
                Console.Write("Digite a especialidade: ");
                string bio = Console.ReadLine()!;

                // Lógica de salvamento aqui
                var instrutor = new Instrutor { Nome = nome, Bio = bio };
                db.Instrutores.Add(instrutor);
                db.SaveChanges();

                Console.WriteLine($"\nInstrutor '{nome}' ({bio}) criado com sucesso!");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                Console.ReadKey();
            }
        }


    }

    private static void InstrutorCriarCurso()
    {
        System.Console.WriteLine("INSTRUTORES");
        System.Console.WriteLine("Nome do Curso: ");
        var nomeCuros = Console.ReadLine()!;
        System.Console.WriteLine("Descrição do Curso: ");
        var descricaoCuros = Console.ReadLine()!;

        var instrutores = db.Instrutores.ToArray();
        foreach (var item in instrutores)
        {
            System.Console.WriteLine($"ID: {item.Id} | Nome: {item.Nome}");
        }
        System.Console.WriteLine("SELECIONE ID DO INSTRUTOR PARA ADD CURSO: ");
        var id = int.Parse(Console.ReadLine()!);

        var idInstrutor = db.Instrutores.FirstOrDefault(x => x.Id == id);

        System.Console.WriteLine("CATEGORIA");
        var categoriaExist = db.Categorias.Any();
        if (categoriaExist)
        {
            var categorias = db.Categorias.ToArray();
            foreach (var item in categorias)
            {
                System.Console.WriteLine($"ID: {item.Id} | Nome: {item.Nome}");
            }
            System.Console.WriteLine("SELECIONE ID DA CATEGORIA: ");
            var idCategoria = int.Parse(Console.ReadLine()!);
            var categoria = db.Categorias.FirstOrDefault(x => x.Id == idCategoria);

            if (idInstrutor != null)
            {
                var curso = new Curso
                {
                    Titulo = nomeCuros,
                    Descricao = descricaoCuros,
                    Categoria = categoria,
                    Instrutor = idInstrutor
                };
                db.Cursos.Add(curso);
                //  Console.ReadKey();

            }
            else
            {
                System.Console.WriteLine("CADASTRAR CATEGORIA");
                System.Console.WriteLine("Nome: ");
                var nome = Console.ReadLine()!;

                if (idInstrutor != null)
                {
                    var curso = new Curso
                    {
                        Titulo = nomeCuros,
                        Descricao = descricaoCuros,
                        Categoria = new Categoria { Nome = nome },
                        Instrutor = idInstrutor
                    };
                    db.Cursos.Add(curso);
                }

            }
            db.SaveChanges();
            System.Console.WriteLine("Salvo");

            Console.ReadKey();
        }






    }

    public static void ListarInstrutor()
    {
        var instrutores = db.Instrutores.ToList();
        foreach (var item in instrutores)
        {
            System.Console.WriteLine($"Instrutor: {item.Nome} - Especialidade: {item.Bio}");
        }
        Console.ReadKey();

    }

    public static void ListarUsuario()
    {
        var usuarios = db.Usuarios.ToList();
        foreach (var item in usuarios)
        {
            System.Console.WriteLine($"Usuario: {item.Nome} - Email: {item.Email}");
            Console.ReadKey();
        }
    }

    public static void DeletarInstrutor()
    {
        var instrutores = db.Instrutores.ToList();
        foreach (var item in instrutores)
        {
            System.Console.WriteLine($"ID: {item.Id} - Instrutor: {item.Nome} - Especialidade: {item.Bio}");
        }
        System.Console.WriteLine("SELECIONE O ID DO INSTRUTOR: ");
        var id = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine($"OpID: {id}");

        var instrutor = db.Instrutores.FirstOrDefault(x => x.Id == id);
        if (instrutor != null)
        {
            db.Instrutores.Remove(instrutor);
            db.SaveChanges();
            System.Console.WriteLine("Instrutor removido com sucesso!");

        }
        else
        {
            System.Console.WriteLine("Instrutor inexistente");
        }
        Console.ReadKey();
    }

    public static void DeletarUsuario()
    {
        var usuarios = db.Usuarios.ToList();
        foreach (var item in usuarios)
        {
            System.Console.WriteLine($"ID: {item.Id} - Usuario: {item.Nome} - Email: {item.Email}");
            // Console.ReadKey();
        }
        System.Console.WriteLine("SELECIONE O ID DO USUÁRIO: ");
        var id = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine($"OpID: {id}");

        var usuario = db.Usuarios
            .FirstOrDefault(x => x.Id == id);

        if (usuario != null)
        {
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            System.Console.WriteLine("Usuario removido com sucesso!");
        }
        else
        {
            System.Console.WriteLine("Usuario inexistente");
        }
        Console.ReadKey();


    }

    public static void EditarInstrutor()
    {
        var instrutores = db.Instrutores.ToList();
        foreach (var item in instrutores)
        {
            System.Console.WriteLine($"ID: {item.Id} | {item.Nome}");
        }

        System.Console.WriteLine("SELECIONE O ID PARA EDITAR");
        var id = int.Parse(Console.ReadLine()!);
        var valida = db.Instrutores.FirstOrDefault(x => x.Id == id);

        if (valida != null)
        {
            System.Console.WriteLine("Digite novo nome: ");
            var nome = Console.ReadLine()!;
            var instrutor = new Instrutor();
            instrutor.Nome = nome;
            db.Instrutores.Update(instrutor);
            System.Console.WriteLine("Nome atualizado!");

        }
        else
        {
            System.Console.WriteLine("Operacao nao realizado");
        }
        Console.ReadKey();


    }

    public static void EditarUsuario()
    {
        throw new NotImplementedException();
    }
}
