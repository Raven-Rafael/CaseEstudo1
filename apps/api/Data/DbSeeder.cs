using System.Collections.Generic;
using CaseEstudo1.Domain;

namespace CaseEstudo1.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.SaboresPrecosPorTamanhos.Any())
            {
                var sabores = context.Sabores.ToList();

                var precos = new List<SaborPrecoPorTamanho>();

                foreach (var sabor in sabores)
                {
                    precos.Add(new SaborPrecoPorTamanho
                    {
                        SaborId = sabor.Id,
                        Tamanho = TamanhoPizzaEnum.Broto,
                        Preco = 33.50M
                    });

                    precos.Add(new SaborPrecoPorTamanho
                    {
                        SaborId = sabor.Id,
                        Tamanho = TamanhoPizzaEnum.Media,
                        Preco = 39.50M
                    });

                    precos.Add(new SaborPrecoPorTamanho
                    {
                        SaborId = sabor.Id,
                        Tamanho = TamanhoPizzaEnum.Grande,
                        Preco = 44.50M
                    });

                    precos.Add(new SaborPrecoPorTamanho
                    {
                        SaborId = sabor.Id,
                        Tamanho = TamanhoPizzaEnum.Big,
                        Preco = 47.50M
                    });

                    precos.Add(new SaborPrecoPorTamanho
                    {
                        SaborId = sabor.Id,
                        Tamanho = TamanhoPizzaEnum.Gigante,
                        Preco = 52.50M
                    });
                }

                context.SaboresPrecosPorTamanhos.AddRange(precos);
            }

            if (!context.Bordas.Any())
            {
                var bordas = new List<Borda>
                {
                    new Borda { Nome = "Cheddar", Preco = 11.00M },
                    new Borda { Nome = "Chocolate Branco", Preco = 11.00M },
                    new Borda { Nome = "Chocolate ao Leite", Preco = 11.00M },
                    new Borda { Nome = "Cream Cheese", Preco = 11.00M },
                    new Borda { Nome = "Requeijão Cremoso", Preco = 11.00M }
                };
                context.Bordas.AddRange(bordas);
            }

            if (!context.BordasPrecosPorTamanhos.Any())
            {
                var precos = new List<BordaPrecoPorTamanho>
                {
                    new BordaPrecoPorTamanho { Tamanho = TamanhoPizzaEnum.Broto, BordaId = 1, Preco = 11.00M },
                    new BordaPrecoPorTamanho { Tamanho = TamanhoPizzaEnum.Media, BordaId = 1, Preco = 11.00M },
                    new BordaPrecoPorTamanho { Tamanho = TamanhoPizzaEnum.Grande, BordaId = 1, Preco = 11.00M },
                    new BordaPrecoPorTamanho { Tamanho = TamanhoPizzaEnum.Big, BordaId = 1, Preco = 13.00M },
                    new BordaPrecoPorTamanho { Tamanho = TamanhoPizzaEnum.Gigante, BordaId = 1, Preco = 16.00M }
                };
                context.BordasPrecosPorTamanhos.AddRange(precos);
            }

            context.SaveChanges();

        }
    }
}