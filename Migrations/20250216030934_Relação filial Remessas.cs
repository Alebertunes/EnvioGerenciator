using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnvioGerenciator.Migrations
{
    /// <inheritdoc />
    public partial class RelaçãofilialRemessas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "filiais",
                columns: table => new
                {
                    FilialId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filiais", x => x.FilialId);
                });

            migrationBuilder.CreateTable(
                name: "remessas",
                columns: table => new
                {
                    RemessaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FilialId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_remessas", x => x.RemessaId);
                    table.ForeignKey(
                        name: "FK_remessas_filiais_FilialId",
                        column: x => x.FilialId,
                        principalTable: "filiais",
                        principalColumn: "FilialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "objetos",
                columns: table => new
                {
                    ObjetoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Patrimonio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RemessaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_objetos", x => x.ObjetoId);
                    table.ForeignKey(
                        name: "FK_objetos_remessas_RemessaId",
                        column: x => x.RemessaId,
                        principalTable: "remessas",
                        principalColumn: "RemessaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_objetos_RemessaId",
                table: "objetos",
                column: "RemessaId");

            migrationBuilder.CreateIndex(
                name: "IX_remessas_FilialId",
                table: "remessas",
                column: "FilialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "objetos");

            migrationBuilder.DropTable(
                name: "remessas");

            migrationBuilder.DropTable(
                name: "filiais");
        }
    }
}
