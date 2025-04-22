using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionClinicaV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clinicas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Clinicas",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Clinicas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Clinicas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Clinicas");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Clinicas");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Clinicas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Clinicas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }
    }
}
