using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlchemyPages.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayersAndEncounters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "IngredientEncounters",
                columns: table => new
                {
                    IngredientEncounterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    ingredientID = table.Column<int>(type: "int", nullable: false),
                    EncounterDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientEncounters", x => x.IngredientEncounterID);
                    table.ForeignKey(
                        name: "FK_IngredientEncounters_Ingredients_ingredientID",
                        column: x => x.ingredientID,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientEncounters_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientEncounters_ingredientID",
                table: "IngredientEncounters",
                column: "ingredientID");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientEncounters_PlayerID",
                table: "IngredientEncounters",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientEncounters");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
