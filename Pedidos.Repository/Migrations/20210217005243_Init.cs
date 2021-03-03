using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pedidos.Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_categoria_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_categoria_produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cidade",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_cidade", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_imagem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    nomearquivo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    principal = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_imagem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    categoriaid = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_produto_tbl_categoria_produto_categoriaid",
                        column: x => x.categoriaid,
                        principalTable: "tbl_categoria_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_endereco",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    logradouro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bairro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    complemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    cidadeid = table.Column<int>(type: "int", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_endereco", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_endereco_tbl_cidade_cidadeid",
                        column: x => x.cidadeid,
                        principalTable: "tbl_cidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_combo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    imagemid = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_combo", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_combo_tbl_imagem_imagemid",
                        column: x => x.imagemid,
                        principalTable: "tbl_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_imagem_produto",
                columns: table => new
                {
                    imagemid = table.Column<int>(type: "int", nullable: false),
                    produtoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_imagem_produto", x => new { x.imagemid, x.produtoid });
                    table.ForeignKey(
                        name: "FK_tbl_imagem_produto_tbl_imagem_imagemid",
                        column: x => x.imagemid,
                        principalTable: "tbl_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_imagem_produto_tbl_produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "tbl_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_promocao_produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    imagemid = table.Column<int>(type: "int", nullable: false),
                    produtoid = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_promocao_produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_promocao_produto_tbl_imagem_imagemid",
                        column: x => x.imagemid,
                        principalTable: "tbl_imagem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_promocao_produto_tbl_produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "tbl_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    enderecoid = table.Column<int>(type: "int", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_cliente", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_cliente_tbl_endereco_enderecoid",
                        column: x => x.enderecoid,
                        principalTable: "tbl_endereco",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_produto_combo",
                columns: table => new
                {
                    produtoid = table.Column<int>(type: "int", nullable: false),
                    comboid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_produto_combo", x => new { x.produtoid, x.comboid });
                    table.ForeignKey(
                        name: "FK_tbl_produto_combo_tbl_combo_comboid",
                        column: x => x.comboid,
                        principalTable: "tbl_combo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_produto_combo_tbl_produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "tbl_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    valortotal = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    entrega = table.Column<TimeSpan>(type: "time", nullable: false),
                    clienteid = table.Column<int>(type: "int", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_pedido_tbl_cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "tbl_cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_produto_pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", precision: 2, nullable: false),
                    preco = table.Column<decimal>(type: "decimal(17,2)", precision: 17, scale: 2, nullable: false),
                    produtoid = table.Column<int>(type: "int", nullable: false),
                    pedidoid = table.Column<int>(type: "int", nullable: false),
                    criadoem = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_produto_pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_produto_pedido_tbl_pedido_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "tbl_pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_produto_pedido_tbl_produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "tbl_produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_cliente_enderecoid",
                table: "tbl_cliente",
                column: "enderecoid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_combo_imagemid",
                table: "tbl_combo",
                column: "imagemid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_endereco_cidadeid",
                table: "tbl_endereco",
                column: "cidadeid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_imagem_produto_produtoid",
                table: "tbl_imagem_produto",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_pedido_clienteid",
                table: "tbl_pedido",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_produto_categoriaid",
                table: "tbl_produto",
                column: "categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_produto_combo_comboid",
                table: "tbl_produto_combo",
                column: "comboid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_produto_pedido_pedidoid",
                table: "tbl_produto_pedido",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_produto_pedido_produtoid",
                table: "tbl_produto_pedido",
                column: "produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_promocao_produto_imagemid",
                table: "tbl_promocao_produto",
                column: "imagemid");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_promocao_produto_produtoid",
                table: "tbl_promocao_produto",
                column: "produtoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_imagem_produto");

            migrationBuilder.DropTable(
                name: "tbl_produto_combo");

            migrationBuilder.DropTable(
                name: "tbl_produto_pedido");

            migrationBuilder.DropTable(
                name: "tbl_promocao_produto");

            migrationBuilder.DropTable(
                name: "tbl_combo");

            migrationBuilder.DropTable(
                name: "tbl_pedido");

            migrationBuilder.DropTable(
                name: "tbl_produto");

            migrationBuilder.DropTable(
                name: "tbl_imagem");

            migrationBuilder.DropTable(
                name: "tbl_cliente");

            migrationBuilder.DropTable(
                name: "tbl_categoria_produto");

            migrationBuilder.DropTable(
                name: "tbl_endereco");

            migrationBuilder.DropTable(
                name: "tbl_cidade");
        }
    }
}
