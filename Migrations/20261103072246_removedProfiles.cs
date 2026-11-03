using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultantRuleConstructor.Migrations
{
    /// <inheritdoc />
    public partial class removedProfiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentProfile");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.AddColumn<bool>(
                name: "ResettlementProgramStatus",
                table: "Rules",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResettlementProgramStatus",
                table: "Rules");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ResettlementProgramStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    RuleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Rules_RuleId",
                        column: x => x.RuleId,
                        principalTable: "Rules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentProfile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredDocumentsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentProfile", x => new { x.ProfileId, x.RequiredDocumentsId });
                    table.ForeignKey(
                        name: "FK_DocumentProfile_Documents_RequiredDocumentsId",
                        column: x => x.RequiredDocumentsId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentProfile_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentProfile_RequiredDocumentsId",
                table: "DocumentProfile",
                column: "RequiredDocumentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_RuleId",
                table: "Profiles",
                column: "RuleId");
        }
    }
}
