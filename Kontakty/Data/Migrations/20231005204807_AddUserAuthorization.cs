using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kontakty.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAuthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Kontakts",
                table: "Kontakts");

            migrationBuilder.RenameTable(
                name: "Kontakts",
                newName: "Kontakt");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Kontakt",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kontakt",
                table: "Kontakt",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "użytkownik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imię = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_użytkownik", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "UniqEmailInKontakt",
                table: "Kontakt",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "użytkownik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kontakt",
                table: "Kontakt");

            migrationBuilder.DropIndex(
                name: "UniqEmailInKontakt",
                table: "Kontakt");

            migrationBuilder.RenameTable(
                name: "Kontakt",
                newName: "Kontakts");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Kontakts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kontakts",
                table: "Kontakts",
                column: "Id");
        }
    }
}
