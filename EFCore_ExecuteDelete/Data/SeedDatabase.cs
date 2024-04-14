using EFCore_ExecuteDelete.Entities;

namespace EFCore_ExecuteDelete.Data;

public class SeedDatabase
{
    public static void PopulaDB(AppDbContext context)
    {
        context.Database.EnsureDeleted();//Exclui o banco
        context.Database.EnsureCreated();//Recria o banco

        context.Clientes.AddRange(Enumerable.Range(1, 500).Select(i =>
        {
            return new Cliente
            {
                Nome = $"{nameof(Cliente.Nome)}-{i}",
                Email = $"{nameof(Cliente.Email)}-{i}",
                Ativo = i % 2 == 0,
                Animais = Enumerable.Range(1, 2).Select(i2 =>
                {
                    return new Animal
                    {
                        Raca = $"{nameof(Animal.Raca)}-{i}-{i2}",
                        Nome = $"{nameof(Animal.Nome)}-{i}-{i2}",
                    };
                }).ToList()
            };
        }));
        context.SaveChanges();
    }
}
