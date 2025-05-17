using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlchemyPages.Migrations
{
    /// <inheritdoc />
    public partial class renamedplayerknowledgebaseTOplayerknowledges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKnowledgeBase_Ingredients_IngredientId",
                table: "PlayerKnowledgeBase");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKnowledgeBase_Players_PlayerID",
                table: "PlayerKnowledgeBase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerKnowledgeBase",
                table: "PlayerKnowledgeBase");

            migrationBuilder.RenameTable(
                name: "PlayerKnowledgeBase",
                newName: "PlayerKnowledges");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerKnowledgeBase_PlayerID_IngredientId",
                table: "PlayerKnowledges",
                newName: "IX_PlayerKnowledges_PlayerID_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerKnowledgeBase_IngredientId",
                table: "PlayerKnowledges",
                newName: "IX_PlayerKnowledges_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerKnowledges",
                table: "PlayerKnowledges",
                column: "PlayerKnowledgeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKnowledges_Ingredients_IngredientId",
                table: "PlayerKnowledges",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKnowledges_Players_PlayerID",
                table: "PlayerKnowledges",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKnowledges_Ingredients_IngredientId",
                table: "PlayerKnowledges");

            migrationBuilder.DropForeignKey(
                name: "FK_PlayerKnowledges_Players_PlayerID",
                table: "PlayerKnowledges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerKnowledges",
                table: "PlayerKnowledges");

            migrationBuilder.RenameTable(
                name: "PlayerKnowledges",
                newName: "PlayerKnowledgeBase");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerKnowledges_PlayerID_IngredientId",
                table: "PlayerKnowledgeBase",
                newName: "IX_PlayerKnowledgeBase_PlayerID_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_PlayerKnowledges_IngredientId",
                table: "PlayerKnowledgeBase",
                newName: "IX_PlayerKnowledgeBase_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerKnowledgeBase",
                table: "PlayerKnowledgeBase",
                column: "PlayerKnowledgeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKnowledgeBase_Ingredients_IngredientId",
                table: "PlayerKnowledgeBase",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerKnowledgeBase_Players_PlayerID",
                table: "PlayerKnowledgeBase",
                column: "PlayerID",
                principalTable: "Players",
                principalColumn: "PlayerID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
