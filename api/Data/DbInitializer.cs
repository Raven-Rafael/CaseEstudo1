using System.Linq;
using CaseEstudo1.Data;
using CaseEstudo1.Domain;
using System.Collections.Generic;

namespace CaseEstudo1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

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
                var cocaCola = new Bebida
                {
                    Nome = "Coca-Cola",
                    Tipo = "Refrigerante",
                    Disponivel = true,
                    Precos = new List<PrecoBebidaPorTamanho>
                    {
                        new PrecoBebidaPorTamanho { Tamanho = TamanhoBebidaEnum.Lata, Preco = 5.00m },
                        new PrecoBebidaPorTamanho { Tamanho = TamanhoBebidaEnum.Garrafa2L, Preco = 10.00m }
                    }
                };

                var guarana = new Bebida
                {
                    Nome = "Guaraná",
                    Tipo = "Refrigerante",
                    Disponivel = true,
                    Precos = new List<PrecoBebidaPorTamanho>
                    {
                        new PrecoBebidaPorTamanho { Tamanho = TamanhoBebidaEnum.Lata, Preco = 4.50m }
                    }
                };

                context.Bebidas.AddRange(cocaCola, guarana);
                context.SaveChanges();
            }
        }
    }
}
