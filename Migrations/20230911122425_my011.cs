using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Project.Migrations
{
    /// <inheritdoc />
    public partial class my011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ProductsCards",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCards_UserId",
                table: "ProductsCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsCards_Users_UserId",
                table: "ProductsCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsCards_Users_UserId",
                table: "ProductsCards");

            migrationBuilder.DropIndex(
                name: "IX_ProductsCards_UserId",
                table: "ProductsCards");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductsCards");
        }
    }
}
