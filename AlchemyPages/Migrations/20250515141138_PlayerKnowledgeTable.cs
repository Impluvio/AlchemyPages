using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlchemyPages.Migrations
{
    /// <inheritdoc />
    public partial class PlayerKnowledgeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerKnowledgeBase",
                columns: table => new
                {
                    PlayerIngredientEncounterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerID = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    qualitiesKnown = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerKnowledgeBase", x => x.PlayerIngredientEncounterID);
                    table.ForeignKey(
                        name: "FK_PlayerKnowledgeBase_Ingredients_Id",
                        column: x => x.Id,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerKnowledgeBase_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "PlayerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerKnowledgeBase_Id",
                table: "PlayerKnowledgeBase",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerKnowledgeBase_PlayerID",
                table: "PlayerKnowledgeBase",
                column: "PlayerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerKnowledgeBase");
        }
    }
}
