using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeadDeveloperId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LeadDeveloperId",
                table: "Projects",
                column: "LeadDeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Developers_LeadDeveloperId",
                table: "Projects",
                column: "LeadDeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Developers_LeadDeveloperId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_LeadDeveloperId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "LeadDeveloperId",
                table: "Projects");
        }
    }
}
