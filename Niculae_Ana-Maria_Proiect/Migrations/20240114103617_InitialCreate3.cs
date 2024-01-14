using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Niculae_Ana_Maria_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembruEchipaSarcina");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MembruEchipaSarcina",
                columns: table => new
                {
                    SarcinaId = table.Column<int>(type: "int", nullable: false),
                    MembruEchipaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembruEchipaSarcina", x => new { x.SarcinaId, x.MembruEchipaId });
                    table.ForeignKey(
                        name: "FK_MembruEchipaSarcina_MembruEchipaId",
                        column: x => x.MembruEchipaId,
                        principalTable: "MembriEchipa",
                        principalColumn: "MembruEchipaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MembruEchipaSarcina_SarcinaId",
                        column: x => x.SarcinaId,
                        principalTable: "Sarcini",
                        principalColumn: "SarcinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembruEchipaSarcina_MembruEchipaId",
                table: "MembruEchipaSarcina",
                column: "MembruEchipaId");
        }
    }
}
