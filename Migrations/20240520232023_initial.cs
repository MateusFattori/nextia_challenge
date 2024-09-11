using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nextia_challenge.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MVC_Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    genero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_nascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVC_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MVC_Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    categoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    valor = table.Column<float>(type: "BINARY_FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVC_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MVC_Promocoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    produto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nome_promocao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    dt_inicio = table.Column<DateTime>(type: "DATE", nullable: false),
                    dt_final = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MVC_Promocoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MVC_Clientes");

            migrationBuilder.DropTable(
                name: "MVC_Produtos");

            migrationBuilder.DropTable(
                name: "MVC_Promocoes");
        }
    }
}
