using EFCore_ExecuteDelete.Data;
using Microsoft.EntityFrameworkCore;

while (true) 
{
    Console.WriteLine("\nIniciando Processamento...");

    Console.WriteLine("\nSelecione a opção : ");
    Console.WriteLine("(1)-Popular as tabelas");
    Console.WriteLine("(2)-Deletar Animais sem ExecuteDelete ");
    Console.WriteLine("(3)-Deletar Animais com ExecuteDelete");
    Console.WriteLine("(4)-Deletar Clientes Inativos");
    Console.WriteLine("(9)-Encerra");

    int opcao = Convert.ToInt32(Console.ReadLine());

    if (opcao == 1)
        PopulaTabelas();
    else if (opcao == 2)
        DeletaAnimaisPadrao();
    else if (opcao == 3)
        DeletaAnimaisComExecuteDelete();
    else if (opcao == 4)
        DeletaClientesInativos();
    else if (opcao == 9)
        break;
        Console.WriteLine("Fim !!!");

    Console.ReadKey();

    static void DeletaAnimaisPadrao()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("\nDeletando Animais...");

            foreach (var animal in context.Animais.Where(a => a.Nome.Contains("1")))
            {
                context.Animais.Remove(animal);
            }
            context.SaveChanges();

            var registros = context.Animais.Count();
            var deletados = 1000 - registros;
            Console.WriteLine($"\nForam excluídos {deletados} animais da tabela\n");
        }
    }

    static void DeletaAnimaisComExecuteDelete()
    {
        using (var context = new AppDbContext())
        {

            Console.WriteLine("\nDeletando Animais...");

            var animaisExcluidos = context.Animais
                                          .Where(p => p.Nome.Contains("1"))
                                          .ExecuteDelete();

            Console.WriteLine($"\n{animaisExcluidos} animais foram excluidos da tabela...");
        }
    }


    static void DeletaClientesInativos()
    {
        using (var context = new AppDbContext())
        {
            Console.WriteLine("\nDeletando os Clientes Inativos...");

            var clientesDeletados = context.Clientes
                                            .Where(p => !p.Ativo)
                                            .ExecuteDelete();

            Console.WriteLine($"\n{clientesDeletados} clientes foram excluidos da tabela...\n");

            var animais = context.Animais.Count();
            Console.WriteLine($"\nAgora existem {animais} animais na tabela Animais");
        }
    }

    static void PopulaTabelas()
    {
        using (var context = new AppDbContext())
        {
            try
            {
                Console.WriteLine("\nPopulando as tabelas...");
                SeedDatabase.PopulaDB(context);

                var clientes = context.Clientes.Count();
                var animais = context.Animais.Count();

                Console.WriteLine($"\nExistem {clientes} clientes");
                Console.WriteLine($"Existem {animais} animais");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar ou acessar o banco : " + ex.Message);
            }
        }
    }
}