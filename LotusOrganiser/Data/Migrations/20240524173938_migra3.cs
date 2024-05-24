using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LotusOrganiser.Migrations
{
    /// <inheritdoc />
    public partial class migra3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TeamId",
                table: "ToDoListItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListItems_TeamId",
                table: "ToDoListItems",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListItems_Teams_TeamId",
                table: "ToDoListItems",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListItems_Teams_TeamId",
                table: "ToDoListItems");

            migrationBuilder.DropIndex(
                name: "IX_ToDoListItems_TeamId",
                table: "ToDoListItems");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "ToDoListItems");
        }
    }
}
