using Microsoft.EntityFrameworkCore.Migrations;

namespace EventPlusLTD.Data.Migrations
{
    public partial class PostScaffold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performers_ActType_ActTypeGenre",
                table: "Performers");

            migrationBuilder.DropIndex(
                name: "IX_Performers_ActTypeGenre",
                table: "Performers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActType",
                table: "ActType");

            migrationBuilder.DropColumn(
                name: "ActTypeGenre",
                table: "Performers");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Performers",
                newName: "GenreID");

            migrationBuilder.AddColumn<int>(
                name: "ActTypeGenreID",
                table: "Performers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "ActType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActType",
                table: "ActType",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_ActTypeGenreID",
                table: "Performers",
                column: "ActTypeGenreID");

            migrationBuilder.AddForeignKey(
                name: "FK_Performers_ActType_ActTypeGenreID",
                table: "Performers",
                column: "ActTypeGenreID",
                principalTable: "ActType",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performers_ActType_ActTypeGenreID",
                table: "Performers");

            migrationBuilder.DropIndex(
                name: "IX_Performers_ActTypeGenreID",
                table: "Performers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActType",
                table: "ActType");

            migrationBuilder.DropColumn(
                name: "ActTypeGenreID",
                table: "Performers");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "ActType");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "Performers",
                newName: "Genre");

            migrationBuilder.AddColumn<string>(
                name: "ActTypeGenre",
                table: "Performers",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActType",
                table: "ActType",
                column: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_Performers_ActTypeGenre",
                table: "Performers",
                column: "ActTypeGenre");

            migrationBuilder.AddForeignKey(
                name: "FK_Performers_ActType_ActTypeGenre",
                table: "Performers",
                column: "ActTypeGenre",
                principalTable: "ActType",
                principalColumn: "Genre",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
