using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserRightMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ushort>(
                name: "client_droit",
                table: "utilisateur",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);

            migrationBuilder.AddColumn<ushort>(
                name: "devis_droit",
                table: "utilisateur",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);

            migrationBuilder.AddColumn<ushort>(
                name: "facture_droit",
                table: "utilisateur",
                type: "smallint unsigned",
                nullable: false,
                defaultValue: (ushort)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "client_droit",
                table: "utilisateur");

            migrationBuilder.DropColumn(
                name: "devis_droit",
                table: "utilisateur");

            migrationBuilder.DropColumn(
                name: "facture_droit",
                table: "utilisateur");
        }
    }
}
