using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketEShop.Repository.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTicketInShoppingCarts",
                table: "MovieTicketInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTicketInOrder",
                table: "MovieTicketInOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTicketInShoppingCarts",
                table: "MovieTicketInShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTicketInOrder",
                table: "MovieTicketInOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTicketInShoppingCarts_MovieTicketId",
                table: "MovieTicketInShoppingCarts",
                column: "MovieTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTicketInOrder_MovieTicketId",
                table: "MovieTicketInOrder",
                column: "MovieTicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTicketInShoppingCarts",
                table: "MovieTicketInShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_MovieTicketInShoppingCarts_MovieTicketId",
                table: "MovieTicketInShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTicketInOrder",
                table: "MovieTicketInOrder");

            migrationBuilder.DropIndex(
                name: "IX_MovieTicketInOrder_MovieTicketId",
                table: "MovieTicketInOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTicketInShoppingCarts",
                table: "MovieTicketInShoppingCarts",
                columns: new[] { "MovieTicketId", "ShoppingCartId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTicketInOrder",
                table: "MovieTicketInOrder",
                columns: new[] { "MovieTicketId", "OrderId" });
        }
    }
}
