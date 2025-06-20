using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class medicaupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllNumber",
                table: "AppMedications");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AppMedications");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "AppMedications",
                newName: "Usage");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "AppMedications",
                newName: "Dosage");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "AppMedications",
                type: "decimal(65,30)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DosageUnit",
                table: "AppMedications",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NumberUnit",
                table: "AppMedications",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosageUnit",
                table: "AppMedications");

            migrationBuilder.DropColumn(
                name: "NumberUnit",
                table: "AppMedications");

            migrationBuilder.RenameColumn(
                name: "Usage",
                table: "AppMedications",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "Dosage",
                table: "AppMedications",
                newName: "Amount");

            migrationBuilder.AlterColumn<string>(
                name: "TotalPrice",
                table: "AppMedications",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AllNumber",
                table: "AppMedications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AppMedications",
                type: "int",
                nullable: true);
        }
    }
}
