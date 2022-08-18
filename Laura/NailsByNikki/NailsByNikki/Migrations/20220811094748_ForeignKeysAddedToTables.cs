using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NailsByNikki.Migrations
{
    public partial class ForeignKeysAddedToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookingsHistory_CustomerId",
                table: "BookingsHistory",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingsHistory_Customers_CustomerId",
                table: "BookingsHistory",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingsHistory_Customers_CustomerId",
                table: "BookingsHistory");

            migrationBuilder.DropIndex(
                name: "IX_BookingsHistory_CustomerId",
                table: "BookingsHistory");
        }
    }
}
