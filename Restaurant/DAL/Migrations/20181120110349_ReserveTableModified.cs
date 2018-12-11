using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ReserveTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_AspNetUsers_UserId1",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_UserId1",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TableId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Reserves",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_UserId",
                table: "Reserves",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_AspNetUsers_UserId",
                table: "Reserves",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_AspNetUsers_UserId",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_UserId",
                table: "Reserves");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Reserves",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Reserves",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_UserId1",
                table: "Reserves",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TableId",
                table: "AspNetUsers",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tables_TableId",
                table: "AspNetUsers",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_AspNetUsers_UserId1",
                table: "Reserves",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
