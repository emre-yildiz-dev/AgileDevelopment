using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AgileDevelopment.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Methodology",
                columns: table => new
                {
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Methodology", x => x.MethodologyID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Methodology_MethodologyID",
                        column: x => x.MethodologyID,
                        principalTable: "Methodology",
                        principalColumn: "MethodologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MethodFrameworks",
                columns: table => new
                {
                    MethodFrameworkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MethodFrameworks", x => x.MethodFrameworkID);
                    table.ForeignKey(
                        name: "FK_MethodFrameworks_Methodology_MethodologyID",
                        column: x => x.MethodologyID,
                        principalTable: "Methodology",
                        principalColumn: "MethodologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Practice",
                columns: table => new
                {
                    PracticeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practice", x => x.PracticeID);
                    table.ForeignKey(
                        name: "FK_Practice_Methodology_MethodologyID",
                        column: x => x.MethodologyID,
                        principalTable: "Methodology",
                        principalColumn: "MethodologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Principle",
                columns: table => new
                {
                    PrincipleID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principle", x => x.PrincipleID);
                    table.ForeignKey(
                        name: "FK_Principle_Methodology_MethodologyID",
                        column: x => x.MethodologyID,
                        principalTable: "Methodology",
                        principalColumn: "MethodologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.TestID);
                    table.ForeignKey(
                        name: "FK_Test_Methodology_MethodologyID",
                        column: x => x.MethodologyID,
                        principalTable: "Methodology",
                        principalColumn: "MethodologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WiseSaying",
                columns: table => new
                {
                    WiseSayingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    MethodologyID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WiseSaying", x => x.WiseSayingID);
                    table.ForeignKey(
                        name: "FK_WiseSaying_Methodology_MethodologyID",
                        column: x => x.MethodologyID,
                        principalTable: "Methodology",
                        principalColumn: "MethodologyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MindSet",
                columns: table => new
                {
                    MindSetID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MemberID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MindSet", x => x.MindSetID);
                    table.ForeignKey(
                        name: "FK_MindSet_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Member_MethodologyID",
                table: "Member",
                column: "MethodologyID");

            migrationBuilder.CreateIndex(
                name: "IX_MethodFrameworks_MethodologyID",
                table: "MethodFrameworks",
                column: "MethodologyID");

            migrationBuilder.CreateIndex(
                name: "IX_MindSet_MemberID",
                table: "MindSet",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Practice_MethodologyID",
                table: "Practice",
                column: "MethodologyID");

            migrationBuilder.CreateIndex(
                name: "IX_Principle_MethodologyID",
                table: "Principle",
                column: "MethodologyID");

            migrationBuilder.CreateIndex(
                name: "IX_Test_MethodologyID",
                table: "Test",
                column: "MethodologyID");

            migrationBuilder.CreateIndex(
                name: "IX_WiseSaying_MethodologyID",
                table: "WiseSaying",
                column: "MethodologyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MethodFrameworks");

            migrationBuilder.DropTable(
                name: "MindSet");

            migrationBuilder.DropTable(
                name: "Practice");

            migrationBuilder.DropTable(
                name: "Principle");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "WiseSaying");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Methodology");
        }
    }
}
