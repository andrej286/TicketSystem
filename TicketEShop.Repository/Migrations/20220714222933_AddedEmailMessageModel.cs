using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketEShop.Repository.Migrations
{
    public partial class AddedEmailMessageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTicketInOrder_MovieTickets_MovieTicketId",
                table: "MovieTicketInOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTicketInOrder_Order_OrderId",
                table: "MovieTicketInOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTicketInOrder",
                table: "MovieTicketInOrder");

            migrationBuilder.RenameTable(
                name: "MovieTicketInOrder",
                newName: "MovieTicketInOrders");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTicketInOrder_OrderId",
                table: "MovieTicketInOrders",
                newName: "IX_MovieTicketInOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTicketInOrder_MovieTicketId",
                table: "MovieTicketInOrders",
                newName: "IX_MovieTicketInOrders_MovieTicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTicketInOrders",
                table: "MovieTicketInOrders",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmailMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MailTo = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessages", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTicketInOrders_MovieTickets_MovieTicketId",
                table: "MovieTicketInOrders",
                column: "MovieTicketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTicketInOrders_Order_OrderId",
                table: "MovieTicketInOrders",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTicketInOrders_MovieTickets_MovieTicketId",
                table: "MovieTicketInOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTicketInOrders_Order_OrderId",
                table: "MovieTicketInOrders");

            migrationBuilder.DropTable(
                name: "EmailMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTicketInOrders",
                table: "MovieTicketInOrders");

            migrationBuilder.RenameTable(
                name: "MovieTicketInOrders",
                newName: "MovieTicketInOrder");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTicketInOrders_OrderId",
                table: "MovieTicketInOrder",
                newName: "IX_MovieTicketInOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTicketInOrders_MovieTicketId",
                table: "MovieTicketInOrder",
                newName: "IX_MovieTicketInOrder_MovieTicketId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTicketInOrder",
                table: "MovieTicketInOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTicketInOrder_MovieTickets_MovieTicketId",
                table: "MovieTicketInOrder",
                column: "MovieTicketId",
                principalTable: "MovieTickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTicketInOrder_Order_OrderId",
                table: "MovieTicketInOrder",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
