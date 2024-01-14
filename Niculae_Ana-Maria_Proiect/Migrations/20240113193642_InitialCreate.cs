using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Niculae_Ana_Maria_Proiect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manageri",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manageri", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "MembriEchipa",
                columns: table => new
                {
                    MembruEchipaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembriEchipa", x => x.MembruEchipaId);
                });

            migrationBuilder.CreateTable(
                name: "Proiecte",
                columns: table => new
                {
                    ProiectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIncepere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalizare = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proiecte", x => x.ProiectId);
                    table.ForeignKey(
                        name: "FK_Proiecte_Manageri_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Manageri",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sarcini",
                columns: table => new
                {
                    SarcinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataIncepere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalizare = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProiectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sarcini", x => x.SarcinaId);
                    table.ForeignKey(
                        name: "FK_Sarcini_Proiecte_ProiectId",
                        column: x => x.ProiectId,
                        principalTable: "Proiecte",
                        principalColumn: "ProiectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarii",
                columns: table => new
                {
                    ComentariuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    ProiectId = table.Column<int>(type: "int", nullable: false),
                    SarcinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarii", x => x.ComentariuId);
                    table.ForeignKey(
                        name: "FK_Comentarii_Proiecte_ProiectId",
                        column: x => x.ProiectId,
                        principalTable: "Proiecte",
                        principalColumn: "ProiectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarii_Sarcini_SarcinaId",
                        column: x => x.SarcinaId,
                        principalTable: "Sarcini",
                        principalColumn: "SarcinaId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "SarcinaMembruEchipa",
                columns: table => new
                {
                    SarcinaId = table.Column<int>(type: "int", nullable: false),
                    MembruEchipaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SarcinaMembruEchipa", x => new { x.SarcinaId, x.MembruEchipaId });
                    table.ForeignKey(
                        name: "FK_SarcinaMembruEchipa_MembriEchipa_MembruEchipaId",
                        column: x => x.MembruEchipaId,
                        principalTable: "MembriEchipa",
                        principalColumn: "MembruEchipaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SarcinaMembruEchipa_Sarcini_SarcinaId",
                        column: x => x.SarcinaId,
                        principalTable: "Sarcini",
                        principalColumn: "SarcinaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarii_ProiectId",
                table: "Comentarii",
                column: "ProiectId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarii_SarcinaId",
                table: "Comentarii",
                column: "SarcinaId");

            migrationBuilder.CreateIndex(
                name: "IX_MembruEchipaSarcina_MembruEchipaId",
                table: "MembruEchipaSarcina",
                column: "MembruEchipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proiecte_ManagerId",
                table: "Proiecte",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_SarcinaMembruEchipa_MembruEchipaId",
                table: "SarcinaMembruEchipa",
                column: "MembruEchipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sarcini_ProiectId",
                table: "Sarcini",
                column: "ProiectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarii");

            migrationBuilder.DropTable(
                name: "MembruEchipaSarcina");

            migrationBuilder.DropTable(
                name: "SarcinaMembruEchipa");

            migrationBuilder.DropTable(
                name: "MembriEchipa");

            migrationBuilder.DropTable(
                name: "Sarcini");

            migrationBuilder.DropTable(
                name: "Proiecte");

            migrationBuilder.DropTable(
                name: "Manageri");
        }
    }
}
