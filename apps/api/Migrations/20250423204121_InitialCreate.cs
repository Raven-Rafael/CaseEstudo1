using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CaseEstudo1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bordas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bordas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sabores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Imagem = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sabores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BordasPrecosPorTamanhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tamanho = table.Column<string>(type: "text", nullable: false),
                    BordaId = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BordasPrecosPorTamanhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BordasPrecosPorTamanhos_Bordas_BordaId",
                        column: x => x.BordaId,
                        principalTable: "Bordas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false),
                    Tamanho = table.Column<string>(type: "text", nullable: false),
                    Disponivel = table.Column<bool>(type: "boolean", nullable: false),
                    BordaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Bordas_BordaId",
                        column: x => x.BordaId,
                        principalTable: "Bordas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaboresIngredientes",
                columns: table => new
                {
                    SaborId = table.Column<int>(type: "integer", nullable: false),
                    IngredienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaboresIngredientes", x => new { x.SaborId, x.IngredienteId });
                    table.ForeignKey(
                        name: "FK_SaboresIngredientes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaboresIngredientes_Sabores_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaboresPrecosPorTamanhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tamanho = table.Column<int>(type: "integer", nullable: false),
                    SaborId = table.Column<int>(type: "integer", nullable: false),
                    Preco = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaboresPrecosPorTamanhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaboresPrecosPorTamanhos_Sabores_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzasSabores",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "integer", nullable: false),
                    SaborId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzasSabores", x => new { x.PizzaId, x.SaborId });
                    table.ForeignKey(
                        name: "FK_PizzasSabores_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzasSabores_Sabores_SaborId",
                        column: x => x.SaborId,
                        principalTable: "Sabores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BordasPrecosPorTamanhos_BordaId",
                table: "BordasPrecosPorTamanhos",
                column: "BordaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_BordaId",
                table: "Pizzas",
                column: "BordaId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzasSabores_SaborId",
                table: "PizzasSabores",
                column: "SaborId");

            migrationBuilder.CreateIndex(
                name: "IX_SaboresIngredientes_IngredienteId",
                table: "SaboresIngredientes",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SaboresPrecosPorTamanhos_SaborId",
                table: "SaboresPrecosPorTamanhos",
                column: "SaborId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BordasPrecosPorTamanhos");

            migrationBuilder.DropTable(
                name: "PizzasSabores");

            migrationBuilder.DropTable(
                name: "SaboresIngredientes");

            migrationBuilder.DropTable(
                name: "SaboresPrecosPorTamanhos");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Sabores");

            migrationBuilder.DropTable(
                name: "Bordas");
        }
    }
}
