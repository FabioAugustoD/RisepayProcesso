using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Risepay.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_cargo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cargo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_colaborador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_colaborador", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_colaborador_tb_cargo_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "tb_cargo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_colaborador_IdCargo",
                table: "tb_colaborador",
                column: "IdCargo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_colaborador");

            migrationBuilder.DropTable(
                name: "tb_cargo");
        }
    }
}
