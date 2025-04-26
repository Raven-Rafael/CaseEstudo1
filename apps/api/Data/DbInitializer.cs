using System.Linq;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;

namespace CaseEstudo1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Verifica se já existem dados para evitar duplicações
            if (!context.Pizzas.Any())
            {
                context.Pizzas.AddRange(
                    new Pizza { Nome = "Margherita", Preco = 25.00m },
                    new Pizza { Nome = "Calabresa", Preco = 30.00m }
                );
                context.SaveChanges();
            }

            if (!context.Bebidas.Any())
            {
                context.Bebidas.AddRange(
                    new Bebida { Nome = "Coca-Cola", Preco = 5.00m },
                    new Bebida { Nome = "Guaraná", Preco = 4.50m }
                );
                context.SaveChanges();
            }
        }
    }
}
