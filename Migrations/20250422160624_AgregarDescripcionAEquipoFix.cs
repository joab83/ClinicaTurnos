using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicaTurnos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDescripcionAEquipoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Equipos");
        }
    }
}
