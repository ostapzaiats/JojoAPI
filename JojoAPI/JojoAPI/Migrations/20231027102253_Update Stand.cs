using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JojoAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Stand_StandId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "StandId",
                table: "Character",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Stand_StandId",
                table: "Character",
                column: "StandId",
                principalTable: "Stand",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Character_Stand_StandId",
                table: "Character");

            migrationBuilder.AlterColumn<int>(
                name: "StandId",
                table: "Character",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Character_Stand_StandId",
                table: "Character",
                column: "StandId",
                principalTable: "Stand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
