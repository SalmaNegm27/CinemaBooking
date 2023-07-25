using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBooking.Migrations
{
    public partial class cartIteamHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItemsHistories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    CheckoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItemsHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CartItemsHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItemsHistories_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CartItemsHistories_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItemsHistories_CartId",
                table: "CartItemsHistories",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemsHistories_MovieId",
                table: "CartItemsHistories",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItemsHistories_UserId",
                table: "CartItemsHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItemsHistories");
        }
    }
}
