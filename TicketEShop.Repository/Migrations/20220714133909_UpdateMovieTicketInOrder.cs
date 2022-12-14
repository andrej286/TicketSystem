using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketEShop.Repository.Migrations
{
    public partial class UpdateMovieTicketInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MovieTicketInOrder",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MovieTicketInOrder");
        }
    }
}
