using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultantRuleConstructor.Migrations
{
    /// <inheritdoc />
    public partial class manyDocuments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rules_Documents_TargetDocumentId",
                table: "Rules");

            migrationBuilder.DropIndex(
                name: "IX_Rules_TargetDocumentId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "TargetDocumentId",
                table: "Rules");

            migrationBuilder.AddColumn<bool>(
                name: "IsTarget",
                table: "Documents",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RuleId",
                table: "Documents",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_RuleId",
                table: "Documents",
                column: "RuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Rules_RuleId",
                table: "Documents",
                column: "RuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Rules_RuleId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_RuleId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IsTarget",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "RuleId",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "TargetDocumentId",
                table: "Rules",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rules_TargetDocumentId",
                table: "Rules",
                column: "TargetDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rules_Documents_TargetDocumentId",
                table: "Rules",
                column: "TargetDocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
